using MediatR;

namespace Application.Queries.Login
{
    public class LoginQuery : IRequest<Model.User>
    {
        public string login { get; set; }
        public string password { get; set; }
    }
}
