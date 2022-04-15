using MusicMarketLogic.Classes;

namespace MusicMarketLogic.Interfaces;

public interface IAdvertisementContainer
{
    public IReadOnlyCollection<Advertisement> GetAdvertisements();
    public void AddAdvertisement(Advertisement advertisement);
    public void RemoveAdvertisement(Advertisement advertisement);
    public List<Advertisement> GetAllAds();
}