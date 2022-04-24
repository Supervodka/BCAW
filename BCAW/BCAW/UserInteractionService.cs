using BCAW.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAW
{
    internal static class UserInteractionService
    {
        public static Offer? AddOffer()
        {
            Console.Clear();
            if (UserService.CountUser() == 0)
            {
                Console.WriteLine("Пользователей нету");
                return null;
            }
            else
            {
                Console.WriteLine("Введите данные для анкеты");
                var offer = new Offer();
                Console.WriteLine("Введите желаемую работу");
                offer.Job = Console.ReadLine();
                Console.WriteLine("Введите опыт работы по желаемой вакансии(полных месяцев)");
                offer.Experience = Console.ReadLine();
                Console.WriteLine("Ведите желаемое вознаграждение");
                offer.Reward = Console.ReadLine();
                Console.WriteLine("Пару слов о себе");
                offer.AFewWords = Console.ReadLine();
                offer.Id = Storage.Offers.Count;
                offer.UserId = UserService.ChooseUser();

                return offer;
            }

        }

        public static User AddUser()
        {
            Console.Clear();
            Console.WriteLine("Введите имя пользователя");

            var name = Console.ReadLine();
            Console.WriteLine("Введите возраст пользователя");

            var age = Convert.ToInt32(Console.ReadLine());
            return new User
            {
                Name = name,
                Age = age,
                Id = UserService.CountUser(),
            };
        }
        public static void UserCount(int userCount)
        {
            Console.WriteLine(userCount);

        }

        // приниммет входящую коллекцию и делает  перебор обьектов и отрисовывает методом DrawOffer каждый по очереди
        public static void DrawOffers(List<Offer> offerCollection)
        {   
            if (offerCollection == null)
            {
                return;
            }
            foreach (var offer in offerCollection)
            {
                DrawOffer(offer);
            }
        }

        //отрисовка полей-данных анкеты
        public static void DrawOffer(Offer offer)
        {
            Console.WriteLine($"offer id:{offer.Id}");
            Console.WriteLine($"Job:{offer.Job}");
            Console.WriteLine($"Experience:{offer.Experience}");
            Console.WriteLine($"Reward:{offer.Reward}");
            Console.WriteLine($"A fer words:{offer.AFewWords}");
            Console.WriteLine();
        }
        public static void CheckAllOffers(List<Offer> offers)
        {
            DrawOffers(offers);
        }
        public static int ConfirmOffer()
        {
            Console.WriteLine("Введите номер выбранной анкеты");
           return Convert.ToInt32(Console.ReadLine());

        }
    }
}
