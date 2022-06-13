using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class MessageDal : IMessage
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    public int AddMessage(MessageDto messageDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO message(Content, Date) " +
                           "VALUES(@content, @date)";
        const string sql2 = "INSERT INTO message_person(MessageId, SenderId, ReceiverId)" +
                            "VALUES(@id, @senderId, @receiverId)";
        var rowsAffected = 0;
        try
        {
            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@content", messageDto.Content);
            rowsAffected += cmd.ExecuteNonQuery();

            using var cmd2 = new SqlCommand(sql2, connection);
            cmd2.Parameters.AddWithValue("@id", messageDto.Id);
            cmd2.Parameters.AddWithValue("@senderId", messageDto.SenderId);
            cmd2.Parameters.AddWithValue("@ReceiverId", messageDto.ReceiverId);
            rowsAffected += cmd2.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return rowsAffected;
    }

    public int RemoveMessage(MessageDto messageDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM message " +
                           "WHERE(Content = @content)";

        const string sql2 = "DELETE FROM message_person " +
                            "WHERE(MessageId = @id)";
        var rowsAffected = 0;
        try
        {
            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@content", messageDto.Content); //todo should be by FK instead
            rowsAffected += cmd.ExecuteNonQuery();

            using var cmd2 = new SqlCommand(sql2, connection);
            cmd2.Parameters.AddWithValue("@id", messageDto.Id);
            rowsAffected += cmd2.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return rowsAffected;
    }

    public List<MessageDto> GetConversation(int senderId, int receiverId)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM message WHERE id IN" +
                                 "(SELECT messageId FROM message_person WHERE ReceiverId = @receiverId AND SenderId = @senderId)", connection);
        var reader = sql.ExecuteReader();

        List<MessageDto> result = new();
        try
        {
            while (reader.Read())
            {
                result.Add(new MessageDto()
                {
                    Content = (string) reader["Content"],
                    ReceiverId = receiverId,
                    SenderId = senderId
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return result;
    }
    
    public List<MessageDto> GetAllConversations()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM message_person",connection);
                               
        var reader = sql.ExecuteReader();

        List<MessageDto> result = new();
        try
        {
            while (reader.Read())
            {
                result.Add(new MessageDto()
                {
                    ReceiverId = (int) reader["ReceiverId"],
                    SenderId = (int) reader["SenderId"]
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return result;
    }
    
    
}