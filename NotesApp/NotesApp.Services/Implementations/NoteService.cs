using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.Dtos.NoteDtos;
using NotesApp.Mappers;
using NotesApp.Services.Interfaces;
using NotesApp.Shared.CustomNoteExceptions;

namespace NotesApp.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IUserRepository _userRepository;

        public NoteService(IRepository<Note> noteRepositpry, IUserRepository userRepository)
        {
            _noteRepository = noteRepositpry;
            _userRepository = userRepository;
        }
        public List<NoteDto> GetAllNotes(int userId)
        {
            List<Note> notesDb = _noteRepository.GetAll();

            return notesDb.Where(x => x.UserId == userId).Select(x => x.ToNoteDto()).ToList();
        }
        public NoteDto GetByIdNote(int id)
        {
            Note noteDB = _noteRepository.GetById(id);

            if(noteDB == null)
                throw new NoteNotFoundException($"Note with the id {id} was not found");

            NoteDto noteDto = noteDB.ToNoteDto();
            return noteDto;
        }
        public void AddNote(AddNoteDto addNoteDto, int userId)
        {
            User userDb = _userRepository.GetById(userId);

            if(userDb == null)
                throw new NoteDataException($"User with the id {userId} was not found");
            if(string.IsNullOrEmpty(addNoteDto.Text))
                throw new NoteDataException("Text is required field");
            if(addNoteDto.Text.Length > 100)
                throw new NoteDataException("Text length must be less than 100 characters");

            Note newNote = addNoteDto.ToNote();
            newNote.User = userDb;
            newNote.UserId = userId;

            _noteRepository.Add(newNote);
        }
        public void UpdateNote(UpdateNoteDto updateNoteDto, int userId)
        {
            Note noteDb = _noteRepository.GetById(updateNoteDto.Id);

            if(noteDb == null)
                throw new NoteNotFoundException($"Note with the id {updateNoteDto.Id} was not found");

            User userDb = _userRepository.GetById(userId);

            if(userDb == null)
                throw new NoteDataException($"User with the id {userId} was not found");
            if(string.IsNullOrEmpty(updateNoteDto.Text))
                throw new NoteDataException("Text is required field");
            if(updateNoteDto.Text.Length > 100)
                throw new NoteDataException("Text length must be less than 100 characters");

            noteDb.Text = updateNoteDto.Text;
            noteDb.Priority = updateNoteDto.Priority;
            noteDb.Tag = updateNoteDto.Tag;
            noteDb.UserId = userId;
            noteDb.User = userDb;

            _noteRepository.Update(noteDb);
        }
        public void DeleteNote(int id)
        {
            Note noteDb = _noteRepository.GetById(id);

            if(noteDb == null)
                throw new NoteNotFoundException($"Note with the id {id} was not found");

            _noteRepository.Delete(noteDb);
        }
    }
}
