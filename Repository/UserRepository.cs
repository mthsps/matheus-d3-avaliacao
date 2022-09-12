using System.Data.SqlClient;
using matheus_d3_avaliacao.Interface;
using matheus_d3_avaliacao.Model;

namespace matheus_d3_avaliacao.Repository;

public class UserRepository : IUser
{

    private readonly string databaseConnection =
        "Server=labsoft.pcs.usp.br;Database=db_19;User Id=usuario_19;Password=;";

    public void CreateUser(User user)
    {
        using (SqlConnection con = new SqlConnection(databaseConnection))
        {
            string queryInsert = "INSERT INTO users (name, email, password) VALUES (@name, @email, @password)";
            con.Open();

            using (SqlCommand command = new SqlCommand(queryInsert, con))
            {
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.ExecuteNonQuery();
            }
        }
    }

    public User GetUser(string email, string password)
    {
        User user = new();

        using (SqlConnection con = new SqlConnection(databaseConnection))
        {
            string querySelect = "SELECT * FROM users WHERE email = @email AND password = @password";
            con.Open();

            SqlDataReader rdr;
            using (SqlCommand command = new SqlCommand(querySelect, con))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    user.Id = Guid.Parse(rdr["user_id"].ToString());
                    user.Name = rdr["name"].ToString();
                    user.Email = rdr["email"].ToString();
                }
            }
        }
        return user;
    }
}