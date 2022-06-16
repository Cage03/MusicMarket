using System.Data.SqlClient;
using System.Security.Cryptography;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketDAL;

public class PersonDal : IPerson
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!";

    public int AddPerson(PersonDto personDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "INSERT INTO person(Username, Email, Password) " +
                           "VALUES(@username, @email, @password)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@username", personDto.Username);
                cmd.Parameters.AddWithValue("@email", personDto.Email);
                cmd.Parameters.AddWithValue("@password", personDto.Password);
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

    public int RemovePerson(PersonDto personDto)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string sql = "DELETE FROM person " +
                           "WHERE(Username = @username)";
        var rowsAffected = 0;
        try
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@username", personDto.Username);
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

    public PersonDto GetPersonByName(string username)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM Person WHERE Username = @username", connection);
        sql.Parameters.AddWithValue("@username", username);

        var result = new PersonDto();
        var reader = sql.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                result = new PersonDto()
                {
                    Email = (string) reader["Email"],
                    Id = (int) reader["Id"],
                    Password = (string) reader["Password"],
                    Username = (string) reader["Username"]
                };
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

    public List<PersonDto> GetAllPersons()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var sql = new SqlCommand("SELECT * FROM person", connection);

        var reader = sql.ExecuteReader();

        List<PersonDto> result = new();
        try
        {
            while (reader.Read())
            {
                result.Add(new PersonDto()
                {
                    Id = (int) reader["Id"],
                    Email = (string) reader["Email"],
                    Username = (string) reader["Username"],
                    Password = (string) reader["Password"]
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