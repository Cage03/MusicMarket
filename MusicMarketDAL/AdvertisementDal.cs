using System.Data.SqlClient;
using MusicMarketInterface;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class AdvertisementDal: IAdvertisement
{
    private const string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

    public int AddAdvertisement(AdvertisementDto advertisementDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO advertisement(Date, Name) " +
                           "VALUES(@date, @name)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@date", advertisementDto.Date);
            cmd.Parameters.AddWithValue("@name", advertisementDto.Name);
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
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
}
