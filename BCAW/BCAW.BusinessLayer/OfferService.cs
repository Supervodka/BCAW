using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAW.BusinessLayer
{
    public  class 
        OfferService : IOfferService 
    {

        public  void AddOffer(Offer offer)
        {
            using var context = new ApplicationContext();
            context.Offers.Add(offer);
            context.SaveChanges();
        }

        //вызывает метод отрисовки всех анкет по отдельности
        //делаем поиск по всем анкетам и передаём в новую коллекцию result
        public  List<Offer> SearchOffer(string offerSearch)
        {
            using var context = new ApplicationContext();
            return context.Offers
                //загуглить про .Include()
                .Where(offer =>
                    offer.Job.Contains(offerSearch))
                .ToList();
        }

        public  void RemoveOffer(int removedOffer)
        {
            using var context = new ApplicationContext();
            var deletedOffer = context.Offers.FirstOrDefault(o => o.Id == removedOffer);
            context.Offers.Remove(deletedOffer);
            context.SaveChanges();
        }
        

        public  List<Offer> GetAllOffers()
        {
            using var context = new ApplicationContext();
            var collection = context.Offers;
            return collection.ToList();
        }
    }
}
