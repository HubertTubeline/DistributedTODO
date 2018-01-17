using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using DistributedToDo.BLL.Interfaces;
using DistributedToDo.DAL.Entities;
using DistributedToDo.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using AutoMapper;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace DistributedToDo.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            ClientProfile profile = Mapper.Map<ClientProfile>(userDto);

            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = profile;
                clientProfile.Id = user.Id;
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public OperationDetails Edit(UserDTO userDto)
        {
            ClientProfile profile = Mapper.Map<ClientProfile>(userDto);
            try
            {
                Database.ClientManager.Edit(profile);
            }
            catch
            {
                return new OperationDetails(false, "Ошибка изменения данных", "");
            }
            return new OperationDetails(true, "Изменения успешно применены", "");
        }

            public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public UserDTO GetUser(string Email)
        {
            UserDTO userDto = Mapper.Map<UserDTO>(Database.ClientManager.GetClient(Email));
            return userDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}