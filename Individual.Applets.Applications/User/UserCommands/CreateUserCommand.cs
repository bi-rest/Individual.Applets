using Individual.Applets.Domain.User.BusinessObjects;
using MediatR;

namespace Individual.Applets.Application.User.UserCommands
{

    /// <summary>
    /// 后期可以领域对象和ViewModel相互转换
    /// </summary>
    public class CreateUserCommand : IRequest<Users>
    {
        public Users User { get; set; }

    }
}
