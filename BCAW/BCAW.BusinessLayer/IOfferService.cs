namespace BCAW.BusinessLayer;

public interface IOfferService
{
    public void AddOffer(Offer offer);

    public void RemoveOffer(int offer);

    public List<Offer> GetAllOffers();

    public List<Offer> SearchOffer(string offerSearch);

}