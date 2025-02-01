using MediatR;

namespace Application.Queries.Login
{
    public class LoginQuery : IRequest<Model.User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
