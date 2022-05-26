namespace GiftSystem.Services
{
    using System.Collections.Generic;
    using GiftSystem.DAL;

    public class UserService : IUserService
    {
        private readonly IUserRepository users;

        public UserService(IUserRepository users)
            => this.users = users;

        public IEnumerable<UserServiceModel> GetUsers(string id)
        {
            if (id == null)
            {
                id = string.Empty;
            }

            var users = this.users.GetAllUsers()
                .Where(u => !u.Email.StartsWith("admin")
                    && u.Id.Contains(id))
                .Select(u => new UserServiceModel
                {
                    Id = u.Id,
                    Credits = u.Credits,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Name = u.Name
                })
                .ToList();

            return users;
        }
    }
}
