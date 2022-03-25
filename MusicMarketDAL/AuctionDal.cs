using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class AuctionDal : IAuction
{
    private const string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";
    
    public int AddAuction(AuctionDto auctionDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO auction(Name, Date) " +
                           "VALUES(@name, @date)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@date", auctionDto.Date);
            cmd.Parameters.AddWithValue("@name", auctionDto.Name);
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
    }

    public int RemoveAuction(AuctionDto auctionDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM auction " +
                           "WHERE(Name = @name)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@name", auctionDto.Name); //todo should be by FK instead
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
    }
}