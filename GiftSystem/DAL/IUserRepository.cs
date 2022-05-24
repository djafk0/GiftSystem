namespace GiftSystem.DAL
{
    using GiftSystem.Data.Models;
    using GiftSystem.Services;

    public interface IUserRepository
    {
        ApplicationUser GetUserByPhoneNumber(string phoneNumber);

        ApplicationUser GetUserById(string userId);

        IEnumerable<ApplicationUser> GetAllUsers();
    }
}
