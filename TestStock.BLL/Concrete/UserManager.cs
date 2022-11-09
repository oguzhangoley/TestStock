using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.BLL.Repositories.Concrete;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Core.Utilities.Hashing;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public UserManager(IUserRepository userRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public IDataResponse<User> Add(UserCreateDto userCreateDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(userCreateDto.Password, out passwordHash, out passwordSalt);
            User user = new User();
            user.Email = userCreateDto.Email;
            user.Surname = userCreateDto.Surname;
            user.Username = userCreateDto.Username;
            user.Balance = userCreateDto.Balance;
            user.Name = userCreateDto.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userRepository.Add(user);
            return new DataResponse<User>(user, true);
        }

        public IDataResponse<List<UserListDto>> GetAll()
        {
            var userList=_userRepository.GetAll();
            var usersListDto = new List<UserListDto>();
            foreach (var item in userList)
            {
                usersListDto.Add(new UserListDto()
                {
                    Id = item.Id,
                    Surname = item.Surname,
                    Username = item.Username,
                    Balance = item.Balance,
                    Name = item.Name,
                    Email = item.Email,
                });

            }
            return new DataResponse<List<UserListDto>>(usersListDto, true);

        }

        public IDataResponse<User> GetByEmail(string email)
        {
            var result = _userRepository.GetByFilter(x => x.Email == email);
            return new DataResponse<User>(result, true);
        }

        public IDataResponse<UserOrderDto> GetByIdOrders(int id)
        {
            var user = _orderRepository.GetByFilter(x => x.UserId == id);
            var product=_productRepository.GetByFilter(x => x.Id == user.ProductId);
            

            var userOrderDto = new UserOrderDto();
            userOrderDto.ProductName = product.Name;
            userOrderDto.ProductQuantity = user.ProductQuantity;
            userOrderDto.Email=_userRepository.GetByFilter(x=>x.Id == user.Id).Email;
            userOrderDto.TotalPrice = product.UnitPrice * user.ProductQuantity;
            userOrderDto.Balance=_userRepository.GetByFilter(x=>x.Id==user.Id).Balance;

            return new DataResponse<UserOrderDto>(userOrderDto, true);


        }

        public List<Role> GetClaims(User user)
        {
            var result = _userRepository.GetClaims(user);
            return result;
        }
    }
}
