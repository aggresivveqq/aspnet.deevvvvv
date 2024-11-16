using System.ComponentModel.DataAnnotations;

namespace NotesApi.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
    }
}
