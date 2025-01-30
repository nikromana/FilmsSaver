using MediatR;
using Microsoft.AspNetCore.Identity;
using Model;

namespace Application.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationCommandResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public async Task<RegistrationCommandResult> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var registrationResult = new RegistrationCommandResult();

            var existedUser = await _userManager.FindByEmailAsync(request.Email);

            if (existedUser != null)
            {
                registrationResult.Error = "User with this email already exists.";
                return registrationResult;
            }

            var user = new User
            {
                UserName = request.Name,
                Email = request.Email,
                PhoneNumber = request.Phone
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                registrationResult.Error = "Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description));
                return registrationResult;
            } 
            
            throw new NotImplementedException();
        }
    }
}
