using NotesApp.Dtos.NoteDtos;

namespace NotesApp.Services.Interfaces
{
    public interface INoteService
    {
        List<NoteDto> GetAllNotes(int userId);
        NoteDto GetByIdNote(int id);
        void AddNote(AddNoteDto addNoteDto, int userId);
        void UpdateNote(UpdateNoteDto updateNoteDto, int userId);
        void DeleteNote(int id);
    }
}
