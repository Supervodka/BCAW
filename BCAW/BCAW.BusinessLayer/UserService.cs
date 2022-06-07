namespace BCAW
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService()
        {
            _context = new ApplicationContext();
        }

        public void AddUser(User user)
        {
            _context.FooUsers.Add(user);

        }
        public int CountUser()
        {
           return ApplicationContext.Users.Count;
        }
        public int ChooseUser()
        {
            Console.WriteLine("Выберите пользователя");
            DrawUsers();
            int userId = Convert.ToInt32(Console.ReadLine());
            if (userId <= ApplicationContext.Users.Count)
            {
                return userId;
            }
            else
            {
                Console.WriteLine("Вы выбрали несуществующего пользователя");
                var a = ChooseUser();
                return a;
            }
        }
        public void DrawUsers()
        {
            foreach (var user in ApplicationContext.Users)
                DrawUser(user);
        }

        public void DrawUser(User user)
        {
            Console.WriteLine($"user id:{user.Id}");
            Console.WriteLine($"user name:{user.Name}");
            Console.WriteLine($"user Age :{user.Age}");
            Console.WriteLine();
        }
    }
}