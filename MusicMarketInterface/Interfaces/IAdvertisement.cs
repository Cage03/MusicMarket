using MusicMarketInterface.DTOs;

namespace MusicMarketInterface.Interfaces;

public interface IAdvertisement
{
    void AddAdvertisement(AdvertisementDto advertisementDto); //TODO void to int later
    int RemoveAdvertisement(AdvertisementDto advertisementDto);
    List<AdvertisementDto> GetAllAds();
}