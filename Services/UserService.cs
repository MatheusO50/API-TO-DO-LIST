using To_Do_List.DTO;
using To_Do_List.Interface;
using To_Do_List.Models;
using To_Do_List.Repository;

namespace To_Do_List.Service
{
    public class UserService : IService<User,UserDto>
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository) {_userRepository = userRepository;}
        public UserDto AddItem(User item)
        {
            var user = _userRepository.AddItem(item);
            return user;
        }
        public UserDto GetItem(long id)
        {
            var user = _userRepository.GetItem(id);
            return user;
        }
        public IEnumerable<UserDto> GetAll() => _userRepository.GetAll();
        public void RemoveItem(long id) => _userRepository.RemoveItem(id);
        public void UpdateItem(UserDto item) => _userRepository.UpdateItem(item);
    }
}