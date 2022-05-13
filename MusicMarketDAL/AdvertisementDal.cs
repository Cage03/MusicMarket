using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class AdvertisementDal : IAdvertisement
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True; //local db

    public void AddAdvertisement(AdvertisementDto advertisementDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO advertisement(Price, Name, Description) " +
                           "VALUES(@price, @name, @description)";
        var rowsAffected = 0; //TODO used later when void = int
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", advertisementDto.Name);
                cmd.Parameters.AddWithValue("@price", advertisementDto.Price);
                cmd.Parameters.AddWithValue("@description", advertisementDto.Description);
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
    }


    public int RemoveAdvertisement(AdvertisementDto advertisementDto)
    {
        //Give success bool?
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM advertisement " +
                           "WHERE(Name = @name)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", advertisementDto.Name); //todo should be by FK instead
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

    public List<AdvertisementDto> GetAllAds()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM advertisement", connection);
        var reader = sql.ExecuteReader();

        List<AdvertisementDto> result = new();
        try
        {
            while (reader.Read())
            {
                result.Add(new AdvertisementDto()
                {
                    Description = (string) reader["Description"],
                    Name = (string) reader["Name"],
                    Price = (double) reader["Price"],
                    Status = (string) reader["Status"]
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