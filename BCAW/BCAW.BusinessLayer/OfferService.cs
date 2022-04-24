using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAW.BusinessLayer
{
    public static class OfferService
    {

        public static void AddOffer(Offer offer)
        {
            { 
                Storage.Offers.Add(offer);
            }
        }
        //вызывает метод отрисовки всех анкет по отдельности
        
        //делаем поиск по всем анкетам и передаём в новую коллекцию result
        public static List<Offer> SearchOffer()
        {
            Console.WriteLine("Введите критерии поиска");
            var offerSearch = Console.ReadLine() ?? "";
            return Storage.Offers
                .Where(offer =>
                    offer.Job.Contains(offerSearch))
                .ToList();
        }

        public static void RemoveOffer(int removedOffer)
        {
            var deletedOffer = Storage.Offers.FirstOrDefault(o => o.Id == removedOffer);
            Storage.Offers.Remove(deletedOffer);
        }



       


        public static List<Offer> GetAllOffers()
        {
            var collection = Storage.Offers;

            return collection;
        }
    }
}
