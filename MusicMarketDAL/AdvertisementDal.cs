using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class AdvertisementDal : IAdvertisement
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True; //local db

    public int AddAdvertisement(AdvertisementDto advertisementDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO advertisement(Price, Name, Description, PersonId) " +
                           "VALUES(@Price, @Name, @Description, @PersonId)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@Name", advertisementDto.Name);
                cmd.Parameters.AddWithValue("@Price", advertisementDto.Price);
                cmd.Parameters.AddWithValue("@Description", advertisementDto.Description);
                cmd.Parameters.AddWithValue("@PersonId", advertisementDto.PersonId);
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


    public int RemoveAdvertisement(AdvertisementDto advertisementDto)
    {
        //Give success bool?
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM advertisement " +
                           "WHERE(Id = @Id)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@Id", advertisementDto.Id); //todo should be by FK instead
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
                    Status = (string) reader["Status"],
                    Id = (int) reader["Id"],
                    PersonId = (int) reader["PersonId"]
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