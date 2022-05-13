using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Interfaces;

namespace MusicMarketLogic.Containers;

public class AdvertisementContainer : IAdvertisementContainer
{
    private List<Advertisement> _advertisements; //maybe read-only?

    private IAdvertisement Advertisement;
    
    public AdvertisementContainer(IAdvertisement iAdvertisement)
    {
        Advertisement = iAdvertisement;
        _advertisements = new List<Advertisement>();
    }
    
    public IReadOnlyCollection<Advertisement> GetAdvertisements()
    {
        return _advertisements;
    }

    public void AddAdvertisement(Advertisement advertisement)
    {
        if (_advertisements.Contains(advertisement))
        {
            throw new ArgumentException("Cannot add duplicate advertisement");
        }
        
        if (string.IsNullOrWhiteSpace(advertisement.Name) || advertisement.Price==0)
        {
            throw new ArgumentException("Not all information is given");
        }
        Advertisement.AddAdvertisement(advertisement.ToDto());
        _advertisements.Add(advertisement);
    }

    public void RemoveAdvertisement(Advertisement advertisement)
    {
        if (!_advertisements.Contains(advertisement))
        {
            throw new ArgumentException("Cannot remove non-contained advertisement");
        }
        _advertisements.Remove(advertisement);
        Advertisement.RemoveAdvertisement(advertisement.ToDto());
    }

    public List<Advertisement> GetAllAds()
    {
        var advertisementDTOs = Advertisement.GetAllAds();
        List<Advertisement> adverts = new();
            foreach (var advertisementDTO in advertisementDTOs)
            {
                adverts.Add(new Advertisement(advertisementDTO));
            }
            return adverts;
    }
}