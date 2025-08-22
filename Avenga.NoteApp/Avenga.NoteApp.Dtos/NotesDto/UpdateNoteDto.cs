using Avenga.NoteApp.Domain.Enums;

namespace Avenga.NoteApp.Dtos.NotesDto
{
    public class UpdateNoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public Tag Tag { get; set; }
        public int UserId { get; set; }
    }
}
