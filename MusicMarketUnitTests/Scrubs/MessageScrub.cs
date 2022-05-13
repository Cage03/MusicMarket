using System.Collections.Generic;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketUnitTests.Stubs;

public class MessageScrub : IMessage
{
    public List<MessageDto> MessageDtos = new();

    public MessageScrub()
    {
        MessageDtos.Add(new MessageDto()
        {
            Content = "Content1",
            ReceiverId = 1,
            SenderId = 2
        });
        MessageDtos.Add(new MessageDto()
        {
            Content = "Content2",
            ReceiverId = 3,
            SenderId = 4
        });
        MessageDtos.Add(new MessageDto()
        {
            Content = "Content3",
            ReceiverId = 5,
            SenderId = 6
        });
    }

    public int AddMessage(MessageDto messageDto)
    {
        MessageDtos.Add(messageDto);
        return 1; //todo all int to void?
    }

    public int RemoveMessage(MessageDto messageDto)
    {
        MessageDtos.Add(messageDto);
        return 1;
    }

    public List<MessageDto> GetConversation(MessageDto messageDto) //todo should be person?
    {
        var returnList = new List<MessageDto>();

        foreach (var dto in MessageDtos)
        {
            if (dto.ReceiverId == messageDto.ReceiverId && dto.SenderId == messageDto.SenderId)
            {
                returnList.Add(dto);
            }
        }

        return returnList;
    }
}