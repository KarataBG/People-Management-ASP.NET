using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Pages.People
{
    public class EditPersonModel : PageModel
    {

        public Person person = new Person();
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=DESKTOP-1HAF0DF;Initial Catalog=mystore;Integrated Security=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * From clients Where id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                person.Id = reader.GetInt32(0);
                                person.Name = reader.GetString(1);
                                person.Description = reader.GetString(2);
                                person.Phone = reader.GetString(3);


                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnPost() 
        {
            int.TryParse(Request.Form["id"], out int id);
            person.Id = id;

            person.Name = Request.Form["Name"];
            person.Description = Request.Form["Description"];
            person.Phone = Request.Form["Phone"];

            //prowerka za dalzhina

            try
            {
                String connectionString = "Data Source=DESKTOP-1HAF0DF;Initial Catalog=mystore;Integrated Security=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Update clients Set name=@name,description=@description,phone=@phone Where id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@name", person.Name);
                        command.Parameters.AddWithValue("@description", person.Description);
                        command.Parameters.AddWithValue("@phone", person.Phone);
                        command.Parameters.AddWithValue("@id", person.Id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            Response.Redirect("/People/Index");
        }
    }
}
