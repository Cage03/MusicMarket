using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;

namespace MusicMarketLogic.Containers;

public class AdvertisementContainer
{
    private IAdvertisement iAdvertisement;
    private List<Advertisement> _advertisements;

    public AdvertisementContainer()
    {
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

        if (string.IsNullOrWhiteSpace(advertisement.Name) || advertisement.Date==null)
        {
            throw new ArgumentException("Not all information is given");
        }
        _advertisements.Add(advertisement);
    }

    public void RemoveAdvertisement(Advertisement advertisement)
    {
        if (!_advertisements.Contains(advertisement))
        {
            throw new ArgumentException("Cannot remove non-contained advertisement");
        }
        _advertisements.Remove(advertisement);
    }
}
