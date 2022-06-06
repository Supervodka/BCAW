using BCAW.BusinessLayer;

namespace BCAW
{
    public class UserInteractionService
    {
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;


        public UserInteractionService(IUserService userService,IOfferService offerService)
        {
            _userService = userService;
            _offerService = offerService;
        }

        public void Run()
        {
            do
            {
                AskUser();
            } while (true);
        }

        void AskUser()
        {
            Console.WriteLine("Что вы хотите?");
            Console.WriteLine("1 - Добавить пользователя");
            Console.WriteLine("2 - Посчитай мне пользователей");
            Console.WriteLine("3 - Добавить анкету");
            Console.WriteLine("4 - Поиск анкеты");
            Console.WriteLine("5 - Отобразить все анкеты");
            Console.WriteLine("6 - Взять заказ");
            Console.WriteLine("7 - Создать комментарий к предложению");
            Console.WriteLine("8 - Редактирование аккаунта");


            var answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    var insertedUser = AddUser();
                    _userService.AddUser(insertedUser);
                    break;
                case 2:
                    var count = _userService.CountUser();
                    UserCount(count);
                    break;

                case 3:
                    var offer = AddOffer();
                    if (offer != null)
                    {
                        _offerService.AddOffer(offer);
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }

                    break;

                case 4:
                    Console.WriteLine("Введите критерии поиска");
                    var search = Console.ReadLine();
                    var searchResult = _offerService.SearchOffer(search);
                    DrawOffers(searchResult);
                    break;

                case 5:
                    var offers = _offerService.GetAllOffers();
                    CheckAllOffers(offers);
                    break;

                case 6:

                    var offerConfirmed = ConfirmOffer();
                    _offerService.RemoveOffer(offerConfirmed);

                    break;

                default:
                    Console.WriteLine("Введите корректное число");
                    break;
            }

        }


        public Offer? AddOffer()
        {
            Console.Clear();
            if (_userService.CountUser() == 0)
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
                offer.UserId = _userService.ChooseUser();

                return offer;
            }

        }

        public User AddUser()
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
                Id = _userService.CountUser(),
            };
        }

        public void UserCount(int userCount)
        {
            Console.WriteLine(userCount);

        }

        // приниммет входящую коллекцию и делает  перебор обьектов и отрисовывает методом DrawOffer каждый по очереди
        public void DrawOffers(List<Offer> offerCollection)
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
        public void DrawOffer(Offer offer)
        {
            Console.WriteLine($"offer id:{offer.Id}");
            Console.WriteLine($"Job:{offer.Job}");
            Console.WriteLine($"Experience:{offer.Experience}");
            Console.WriteLine($"Reward:{offer.Reward}");
            Console.WriteLine($"A fer words:{offer.AFewWords}");
            Console.WriteLine();
        }

        public void CheckAllOffers(List<Offer> offers)
        {
            DrawOffers(offers);
        }

        public int ConfirmOffer()
        {
            Console.WriteLine("Введите номер выбранной анкеты");
            return Convert.ToInt32(Console.ReadLine());

        }
    }
}
