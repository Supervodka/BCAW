using BCAW;
using BCAW.BusinessLayer;
using System.Collections.Generic;


do
{
    AskUser();
} while (true);

 static void AskUser()
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
            var insertedUser = UserInteractionService.AddUser();
            UserService.AddUser(insertedUser); 
            break;
        case 2: 
            var count = UserService.CountUser();
            UserInteractionService.UserCount(count);
            break;

        case 3:
            var offer = UserInteractionService.AddOffer();
            if (offer != null)
            {
                OfferService.AddOffer(offer); 
            } 
            else
            {
                Console.WriteLine("Not found");
            }

            break;

        case 4: 
            var searchResult = OfferService.SearchOffer();
            UserInteractionService.DrawOffers(searchResult);
            break;

        case 5: 
            var offers = OfferService.GetAllOffers();
            UserInteractionService.CheckAllOffers(offers);
            break;

        case 6:

            var offerConfirmed = UserInteractionService.ConfirmOffer();
            OfferService.RemoveOffer(offerConfirmed);
          
            break;

        default:
            Console.WriteLine("Введите корректное число");
            break ; 
    }
   
}
