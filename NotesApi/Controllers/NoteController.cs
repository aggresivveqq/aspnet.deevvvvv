using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private static List<NoteModel> noteModels = new List<NoteModel>();
        [HttpGet]
        public IActionResult TakeAll()
        {
            return Ok(noteModels);
        }
        [HttpPost]
        public IActionResult Add(NoteModel note)
        {
            note.Id = noteModels.Count + 1;
            noteModels.Add(note);
            return CreatedAtAction(nameof(TakeAll), new { id = note.Id }, note);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, NoteModel UpdatedNote)
        {
            var note = noteModels.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            note.Title = UpdatedNote.Title;
            note.Content = UpdatedNote.Content;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var note = noteModels.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            noteModels.Remove(note);
            return NoContent();

        }
    }
}