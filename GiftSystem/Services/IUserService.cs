namespace GiftSystem.Services
{
    public interface IUserService
    {
        IEnumerable<UserServiceModel> GetUsers(string id);
    }
}
