using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class AuctionDal : IAuction
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    public int AddAuction(AuctionDto auctionDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO auction(Name, PersonId, CurrentPrice) " +
                           "VALUES(@name, @personId, @currentPrice)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", auctionDto.Name);
                cmd.Parameters.AddWithValue("@personId", auctionDto.PersonId);
                cmd.Parameters.AddWithValue("@currentPrice", auctionDto.CurrentPrice);
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

    public int RemoveAuction(AuctionDto auctionDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM auction " +
                           "WHERE(Name = @name)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", auctionDto.Name); //todo should be by FK instead
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

    public List<AuctionDto> GetAllAuctions()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM auction", connection);
        var reader = sql.ExecuteReader();

        List<AuctionDto> result = new();
        try
        {
            while (reader.Read())
            {
                result.Add(new AuctionDto()
                {
                    Date = (DateTime) reader["Date"],
                    Name = (string) reader["Name"],
                    PersonId = (int) reader["PersonId"],
                    CurrentPrice = (double) reader["CurrentPrice"]
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

    public int UpdateCurrentPrice(AuctionDto auctionDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        

        const string sql = "UPDATE [auction]" +
                           "SET [CurrentPrice] = @CurrentPrice";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@CurrentPrice", auctionDto.CurrentPrice);
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
}