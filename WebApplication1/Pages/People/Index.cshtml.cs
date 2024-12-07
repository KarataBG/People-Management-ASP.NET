using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Pages.People
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

			try
			{
				String connectionString = "Data Source=DESKTOP-1HAF0DF;Initial Catalog=mystore;Integrated Security=True;Trust Server Certificate=True";
				using(SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "Select * From clients";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								person = new Person();
                                person.Id =
									reader.GetInt32(0);
                                person.Name = reader.GetString(1);
                                person.Description = reader.GetString(2);
                                person.Phone = reader.GetString(3);

								listPeople.Add(person);

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

        //[BindProperty]
        public Person person = new Person();

        public List<Person> listPeople { get; set; } = new List<Person>();

    }
}
