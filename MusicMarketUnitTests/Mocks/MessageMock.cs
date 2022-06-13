using System.Collections.Generic;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketUnitTests.Mocks;

public class MessageMock : IMessage
{
    public List<MessageDto> MessageDtos = new();

    public MessageMock()
    {
        MessageDtos.Add(new MessageDto()
        {
            Id = 1,
            Content = "Content1",
            ReceiverId = 1,
            SenderId = 2
        });
        MessageDtos.Add(new MessageDto()
        {
            Id = 2,
            Content = "Content2",
            ReceiverId = 3,
            SenderId = 4
        });
        MessageDtos.Add(new MessageDto()
        {
            Id = 3,
            Content = "Content3",
            ReceiverId = 5,
            SenderId = 6
        });
    }

    public int AddMessage(MessageDto messageDto)
    {
        MessageDtos.Add(messageDto);
        return messageDto.Id;
    }

    public int RemoveMessage(MessageDto messageDto)
    {
        MessageDtos.Add(messageDto);
        return messageDto.Id;
    }

    public List<MessageDto> GetConversation(int senderId, int receiverId) 
    {
        var returnList = new List<MessageDto>();

        foreach (var dto in MessageDtos)
        {
            if (dto.ReceiverId == receiverId && dto.SenderId == senderId)
            {
                returnList.Add(dto);
            }
        }

        return returnList;
    }

    public List<MessageDto> GetAllConversations()
    {
        return MessageDtos;
    }
}