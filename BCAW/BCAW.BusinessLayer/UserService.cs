using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCAW;

namespace BCAW
{
    public static class UserService
    {

        public static void AddUser(User user)
        {
           
            Storage.Users.Add(user);
        }
        public static int CountUser()
        {
           return Storage.Users.Count;
        }
        public static int ChooseUser()
        {
            Console.WriteLine("Выберите пользователя");
            DrawUsers();
            int userId = Convert.ToInt32(Console.ReadLine());
            if (userId <= Storage.Users.Count)
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


        public static void DrawUsers()
        {
            foreach (var user in Storage.Users)
                DrawUser(user);
        }
        public static void DrawUser(User user)
        {
            Console.WriteLine($"user id:{user.Id}");
            Console.WriteLine($"user name:{user.Name}");
            Console.WriteLine($"user Age :{user.Age}");
            Console.WriteLine();
        }
    }
}