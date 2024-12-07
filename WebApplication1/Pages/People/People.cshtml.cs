using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages.People
{
    public class PeopleModel : PageModel
    {

        private readonly InMemoryDB inMemoryDB;

        [BindProperty]
        public Person Person { get; set; }

        public List<Person> listPeople { get; set; } = new List<Person>();

        public PeopleModel(InMemoryDB inMemoryDB)
        {
            this.inMemoryDB = inMemoryDB;
        }
        public void OnGet()
        {
            listPeople = inMemoryDB.People.ToList();
        }

        public IActionResult OnPost()
        {
            inMemoryDB.People.Add(Person);
            inMemoryDB.SaveChanges();
            return RedirectToPage("/InputSuccess");
        }
    }
}
