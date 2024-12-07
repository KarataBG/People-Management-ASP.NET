using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Pages.People
{
    public class AddPersonModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            //proweri person poleta

            try
            {
                String connectionString = "Data Source=DESKTOP-1HAF0DF;Initial Catalog=mystore;Integrated Security=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Insert into clients (name,description,phone) Values (@name,@description,@phone)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                       
                            command.Parameters.AddWithValue("@name",person.Name);
                            command.Parameters.AddWithValue("@description",person.Description);
                            command.Parameters.AddWithValue("@phone",person.Phone);

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
