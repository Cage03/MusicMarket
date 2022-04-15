using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class MessageDal : IMessage
{
    private const string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    public int AddMessage(MessageDto messageDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO message(Content, Date) " +
                           "VALUES(@content, @date)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@content", messageDto.Content);
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
    }

    public int RemoveMessage(MessageDto messageDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM message " +
                           "WHERE(Content = @content)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@content", messageDto.Content); //todo should be by FK instead
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
    }
}