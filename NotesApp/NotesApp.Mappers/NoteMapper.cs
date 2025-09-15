using NotesApp.Domain.Models;
using NotesApp.Dtos.NoteDtos;

namespace NotesApp.Mappers
{
    public static class NoteMapper
    {
        public static NoteDto ToNoteDto(this Note note)
        {
            return new NoteDto()
            {
                Tag = note.Tag,
                Priority = note.Priority,
                Text = note.Text,
                UserFullName = $"{note.User.FirstName} {note.User.LastName}"
            };
        }

        public static Note ToNote(this AddNoteDto addNoteDto)
        {
            return new Note()
            {
                Text = addNoteDto.Text,
                Tag = addNoteDto.Tag,
                Priority = addNoteDto.Priority,
                UserId = addNoteDto.UserId
            };
        }
    }
}
