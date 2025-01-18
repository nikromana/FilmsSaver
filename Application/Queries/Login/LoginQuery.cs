using MediatR;

namespace Application.Queries.Login
{
    public class LoginQuery : IRequest<Model.User>
    {
    }
}
