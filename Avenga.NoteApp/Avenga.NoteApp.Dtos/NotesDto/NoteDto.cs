using Avenga.NoteApp.Domain.Enums;

namespace Avenga.NoteApp.Dtos.NotesDto
{
    public class NoteDto
    {
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public Tag Tag {  get; set; }
        public string UserFullName { get; set; }
    }
}
