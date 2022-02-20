using BCAW;

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
    Console.WriteLine("6 - Принять предложение");
    Console.WriteLine("7 - Создать комментарий к предложению");
    Console.WriteLine("8 - Редактирование аккаунта");
  

    var answer = Convert.ToInt32(Console.ReadLine());
    switch (answer)
    {
        case 1: AddUser(); break;
        case 2: CountUser(); break;
        case 3: AddOffer(); break;
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
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Age);
        }
        Console.ReadKey();
    }
   
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

    }





}

