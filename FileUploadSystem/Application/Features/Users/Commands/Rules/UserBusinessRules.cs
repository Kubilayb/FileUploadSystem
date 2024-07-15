using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCannotBeDuplicatedWhenInserted(string email)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("This email is already taken.");
        }

        public async Task EmailCannotBeDuplicatedWhenUpdated(string email, int id)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email && u.Id != id);
            if (user != null) throw new BusinessException("This email is already taken.");
        }
    }
}
