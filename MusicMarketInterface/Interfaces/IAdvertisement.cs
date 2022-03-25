using MusicMarketInterface.DTOs;

namespace MusicMarketInterface.Interfaces;

public interface IAdvertisement
{
    int AddAdvertisement(AdvertisementDto advertisementDto);
    int RemoveAdvertisement(AdvertisementDto advertisementDto);
}