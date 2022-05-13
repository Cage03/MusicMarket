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
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@content", messageDto.Content);
                rowsAffected = cmd.ExecuteNonQuery();
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

        return rowsAffected;
    }

    public int RemoveMessage(MessageDto messageDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM message " +
                           "WHERE(Content = @content)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@content", messageDto.Content); //todo should be by FK instead
                rowsAffected = cmd.ExecuteNonQuery();
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

        return rowsAffected;
    }

    public List<MessageDto> GetConversation(MessageDto messageDto) //todo refactor this to use Dto, param should be person?
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM message WHERE ReceiverId = @ReceiverId AND SenderId = @SenderId");
        var reader = sql.ExecuteReader();

        List<MessageDto> result = new();
        try
        {
            while (reader.Read())
            {
                result.Add(new MessageDto()
                {
                    Content = (string) reader["Content"],
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