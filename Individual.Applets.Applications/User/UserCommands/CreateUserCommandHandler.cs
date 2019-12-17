using Individual.Applets.Application.User.UserCommands;
using Individual.Applets.Domain.User;
using Individual.Applets.Domain.User.BusinessObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Individual.Applets.Application.User.UserCommands
{
    /// <summary>
    /// 创建的user领域事件返回到应用层 来做一系列处理
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Users>
    {
        /// <summary>
        /// User仓储实现
        /// </summary>
        private IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<Users> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
             _userRepository.Add(request.User);
            
            await _userRepository.UnitOfWork.SaveEntitiesAsync();
            return request.User;
        }
    }
}
