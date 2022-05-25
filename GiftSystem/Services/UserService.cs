namespace GiftSystem.Services
{
    using System.Collections.Generic;
    using GiftSystem.DAL;

    public class UserService : IUserService
    {
        private readonly IUserRepository users;

        public UserService(IUserRepository users) 
            => this.users = users;

        public IEnumerable<UserServiceModel> GetUsers()
            => this.users.GetAllUsers()
                .Where(u => !u.Email.StartsWith("admin"))
                .Select(u => new UserServiceModel
                {
                    Credits = u.Credits,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Name = u.Name
                })
                .ToList();
    }
}
