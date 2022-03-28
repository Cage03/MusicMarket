using System.Data.SqlClient;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class PersonDal : IPerson
{
    private const string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    public int AddPerson(PersonDto personDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO person(Username, Email) " +
                           "VALUES(@username, @email)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@username", personDto.Username);
            cmd.Parameters.AddWithValue("@email", personDto.Email);
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
    }

    public int RemovePerson(PersonDto personDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM person " +
                           "WHERE(Username = @username)";
        var rowsAffected = 0;
        using (var cmd = new SqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@username", personDto.Username);
            rowsAffected = cmd.ExecuteNonQuery();
        }
        connection.Close();

        return rowsAffected;
    }
}