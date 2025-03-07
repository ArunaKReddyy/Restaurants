using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Commands.UpdateUserDetails
{
    class UpdateUseDetailsCommandHandler(
        ILogger<UpdateUseDetailsCommand> logger,
        IUserContext userContext,
        IUserStore<User> userStore) : IRequestHandler<UpdateUseDetailsCommand>
    {
        public async Task Handle(UpdateUseDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.CurrentUser() ?? throw new InvalidOperationException("User not found");
            logger.LogInformation("updating details for {userid} and the {@request}",
                                  user.UserId,
                                  request);

            var dbUser = await userStore.FindByIdAsync(user.UserId, cancellationToken);

            dbUser.Nationality = request.Nationality;
            dbUser.DateOfBirth = request.DateOfBirth;

            await userStore.UpdateAsync(dbUser, cancellationToken);

        }
    }
}
