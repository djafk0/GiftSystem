namespace GiftSystem.DAL
{
    using GiftSystem.Data;
    using GiftSystem.Data.Models;

    public class UserRepository : IUserRepository
    {
        private GiftSystemDbContext context;

        public UserRepository(GiftSystemDbContext context)
            => this.context = context;

        public ApplicationUser GetUserByPhoneNumber(string phoneNumber)
            => this.context.Users
                .FirstOrDefault(u => u.PhoneNumber == phoneNumber);

        public ApplicationUser GetUserById(string userId)
            => this.context.Users.Find(userId);
    }
}
