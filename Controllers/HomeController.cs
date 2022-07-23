using Microsoft.AspNetCore.Mvc;
using WebTatIntek.Entity;
using WebTatIntek.Models;

namespace WebTatIntek.Controllers
{
    public class HomeController : Controller
    {
        List<Notes> notes = new List<Notes>();

        public ActionResult Index([FromServices] DataContext context)
        {
            CheckAuthorization.Check(HttpContext, this);

            if (ViewData["Login"] == null)
                return Redirect("/Account/Login");

            return View();
        }

        /// <summary>
        /// для ajax вывода. Возвращает заметки в виде List
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<Notes> TableData([FromServices] DataContext context)
        {
            CheckAuthorization.Check(HttpContext, this);
            if (notes.Count > 0)
            {
                notes.Clear();
            }
            
            var a = context.Notes.Join(
                context.UsersNotes,
                notes => notes.NoteId,
                usersNotes => usersNotes.Id,
                (notes, user) => new
                {
                    notes.NoteId,
                    notes.Title,
                    notes.Description,
                    user.UserId
                }
                ).Where(x => x.UserId == (context.Users.FirstOrDefault(x => x.Login == ViewData["Login"]).UserId))
                .OrderByDescending(x => x.NoteId).ToList();

            foreach (var item in a)
            {
                notes.Add(new Notes()
                {
                    NoteId = item.NoteId,
                    Title = item.Title,
                    Description = item.Description
                });
            }

            return notes;
        }

    }
}
