namespace GiftSystem.DAL
{
    using GiftSystem.Data.Models;

    public interface IUserRepository
    {
        ApplicationUser GetUserByPhoneNumber(string phoneNumber);

        ApplicationUser GetUserById(string userId);
    }
}
