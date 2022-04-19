using BCAW;
using System.Collections.Generic;

do
{
    AskUser();
} while (true);

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
        case 1: AddUser(); break;
        case 2: CountUser(); break;
        case 3: AddOffer(); break;
        case 4: SearchOffer(); break;
        case 5:CheckAllOffers(); break;
        case 6: ConfirmOffer(); break;
        default:
            Console.WriteLine("Введите корректное число");
            break ; 
    }
   
}

void AddUser()
{
    Console.Clear();
    Console.WriteLine("Введите имя пользователя");
    
    var name = Console.ReadLine();
    Console.WriteLine("Введите возраст пользователя");
   
    var age = Convert.ToInt32(Console.ReadLine());
    var user = new User();
    user.Name = name;
    user.Age = age;
    user.Id = Storage.Users.Count;
    Storage.Users.Add(user);

}
void CountUser()
{
    Console.Clear();
   if (Storage.Users.Count == 0){
        Console.WriteLine("Список пуст");
    } 
   else
    {
        Console.WriteLine($"количество пользователей : {Storage.Users.Count}");
        foreach (var user in Storage.Users)
        {
            Console.WriteLine($"user name:{user.Name}");
            Console.WriteLine($"user Age :{user.Age}");
        }
        Console.ReadKey();
    }
}
int ChooseUser()
{
    Console.WriteLine("Выберите пользователя");
    DrawUsers();
    int userId = Convert.ToInt32(Console.ReadLine());
    if (userId <= Storage.Users.Count)
    {
        return userId;
    }
    else {
        Console.WriteLine("Вы выбрали несуществующего пользователя");
        var a = ChooseUser();
        return a;
    }
}
   

void DrawUsers()
{
    foreach (var user in Storage.Users)
        DrawUser(user);
}
void DrawUser(User user)
{
    Console.WriteLine($"user id:{user.Id}");
    Console.WriteLine($"user name:{user.Name}");
    Console.WriteLine($"user Age :{user.Age}");
    Console.WriteLine();
}

void AddOffer()
{
    Console.Clear();
    if (Storage.Users.Count == 0)
    {
        
        Console.WriteLine("Пользователей нету");
        AskUser();
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
        offer.UserId = ChooseUser();
        Storage.Offers.Add(offer);
    }
}
//вызывает метод отрисовки всех анкет по отдельности
void CheckAllOffers()
{
    DrawOffers(Storage.Offers);
}
//делаем поиск по всем анкетам и передаём в новую коллекцию result
void SearchOffer()
{
    Console.WriteLine("Введите критерии поиска");
    var offerSearch = Console.ReadLine();
    var result = Storage.Offers
        .Where(offer => 
            offer.Job.Contains(offerSearch))
        .ToList();
    DrawOffers(result);//вызывает DrawOffers и передает в него параметр являющийся коллекцией
}
// приниммет входящую коллекцию и делает  перебор обьектов и отрисовывает методом DrawOffer каждый по очереди
void DrawOffers(List<Offer> offerCollection)
{
    foreach (var offer in offerCollection)
    {
        DrawOffer(offer);
    }
}
//отрисовка полей-данных анкеты
void DrawOffer(Offer offer)
{
    Console.WriteLine($"offer id:{offer.Id}");
    Console.WriteLine($"Job:{offer.Job}");
    Console.WriteLine($"Experience:{offer.Experience}");
    Console.WriteLine($"Reward:{offer.Reward}");
    Console.WriteLine($"A fer words:{offer.AFewWords}");
    Console.WriteLine();
}
void ConfirmOffer()
{
    Console.WriteLine("Выберите заказ");
    DrawOffers(Storage.Offers);
    int confirmedOfferId = Convert.ToInt32(Console.ReadLine());
    Storage.Offers.RemoveAt(confirmedOfferId);
}