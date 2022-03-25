using MusicMarketInterface.DTOs;

namespace MusicMarketInterface.Interfaces;

public interface IMessage
{
    int AddMessage(MessageDto messageDto);

    int RemoveMessage(MessageDto messageDto);
}