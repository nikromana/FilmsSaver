using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Registration
{
    public class RegistrationCommand : IRequest<RegistrationCommandResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone {  get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
