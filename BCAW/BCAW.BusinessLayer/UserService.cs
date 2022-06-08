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
            _context.SaveChanges();
        }
        public int CountUser()
        {
           return _context.FooUsers.Count();
        }
        public int ChooseUser()
        {
            Console.WriteLine("Выберите пользователя");
            DrawUsers();
            int userId = Convert.ToInt32(Console.ReadLine());
            if (userId <= _context.FooUsers.Count())
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
            foreach (var user in _context.FooUsers)
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