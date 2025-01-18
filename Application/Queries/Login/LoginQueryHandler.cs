using MediatR;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, User>
    {
        public async  Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            //TODO Add db context and return current user
            throw new NotImplementedException();
        }
    }
}
