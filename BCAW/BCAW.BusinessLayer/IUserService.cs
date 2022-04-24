namespace BCAW;

public interface IUserService
{
    void AddUser(User user);

    int CountUser();

    int ChooseUser();

    void DrawUsers();

    void DrawUser(User user);
}