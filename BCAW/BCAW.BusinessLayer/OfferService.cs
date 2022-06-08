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
        private readonly ApplicationContext _context;
        public OfferService()
        {
            _context = new ApplicationContext();
        }

        public  void AddOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        //вызывает метод отрисовки всех анкет по отдельности
        //делаем поиск по всем анкетам и передаём в новую коллекцию result
        public  List<Offer> SearchOffer(string offerSearch)
        {
            return _context.Offers
                //загуглить про .Include()
                .Where(offer =>
                    offer.Job.Contains(offerSearch))
                .ToList();
        }

        public  void RemoveOffer(int removedOffer)
        {
            var deletedOffer = _context.Offers.FirstOrDefault(o => o.Id == removedOffer);
            _context.Offers.Remove(deletedOffer);
            _context.SaveChanges();
        }
        
        public  List<Offer> GetAllOffers()
        {
            return _context.Offers.ToList();
        }
    }
}
