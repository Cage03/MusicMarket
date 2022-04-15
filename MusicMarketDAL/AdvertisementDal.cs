using System.Data.SqlClient;
using MusicMarketInterface;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class AdvertisementDal : IAdvertisement
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

    public void AddAdvertisement(AdvertisementDto advertisementDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO advertisement(Price, Name, Description) " +
                           "VALUES(@price, @name, @description)";
        var rowsAffected = 0; //used later when void = int
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@name", advertisementDto.Name);
            cmd.Parameters.AddWithValue("@price", advertisementDto.Price);
            cmd.Parameters.AddWithValue("@description", advertisementDto.Description);
            rowsAffected = cmd.ExecuteNonQuery();
        }

        connection.Close();
    }

    
    public int RemoveAdvertisement(AdvertisementDto advertisementDto)
    {
        //Give success bool?
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM advertisement " +
                           "WHERE(Name = @name)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@name", advertisementDto.Name); //todo should be by FK instead
            rowsAffected = cmd.ExecuteNonQuery();
        }

        connection.Close();

        return rowsAffected;
    }

    public List<AdvertisementDto> GetAllAds()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM advertisement", connection);
        var reader = sql.ExecuteReader();

        List<AdvertisementDto> result = new();
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
        connection.Close();
        return result;
    }
}


