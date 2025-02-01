using MediatR;
using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Login
{
    public class LoginQueryHandler(UserManager<User> _userManager) : IRequestHandler<LoginQuery, User>
    {
        public async  Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var existedUser = await _userManager.FindByEmailAsync(request.Login);

            if(existedUser == null)
            {
                return null;
            }

            return existedUser;
        }
    }
}
