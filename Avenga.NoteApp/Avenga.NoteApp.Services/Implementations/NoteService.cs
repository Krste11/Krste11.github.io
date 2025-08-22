using Avenga.NoteApp.DataAccess;
using Avenga.NoteApp.Domain.Models;
using Avenga.NoteApp.Dtos.NotesDto;
using Avenga.NoteApp.Mappers;
using Avenga.NoteApp.Services.Interfaces;
using Avenga.NoteApp.Shared.CustomExceptions;

namespace Avenga.NoteApp.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<User> _userRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public void AddNote(AddNoteDto addNoteDto)
        {
            // 1. Validation 
            User userDb = _userRepository.GetById(addNoteDto.UserId);
            if(userDb == null) throw new NoteDataException($"User with id {addNoteDto.UserId} does not exsist!");
            if(string.IsNullOrWhiteSpace(addNoteDto.Text)) throw new NoteDataException("The field is requird");
            if(addNoteDto.Text.Length > 100) throw new Exception("Text cannot cantain more than 100 characters");

            // 2. Map DTO to Domain Model
            Note newNote = addNoteDto.ToNote();
            newNote.User = userDb;

            // 3. Add new note to the db
            _noteRepository.Add(newNote);
        }

        public void DeleteNote(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if (noteDb == null) throw new NoteNotFoundException($"Note with id {id} does not exist!");

            _noteRepository.Delete(noteDb);
        }

        public List<NoteDto> GetAllNotes()
        {
            var notesDb = _noteRepository.GetAll();
            return notesDb.Select(x => x.ToNoteDto()).ToList();
        }

        public NoteDto GetById(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if(noteDb == null) throw new NoteNotFoundException($"Note with id {id} does not exist!");
            NoteDto noteDto = noteDb.ToNoteDto();
            return noteDto;
        }

        public void UpdateNote(UpdateNoteDto updateNoteDto)
        {
            // 1. Validation
            Note noteDb = _noteRepository.GetById(updateNoteDto.Id);
            if(noteDb == null) throw new NoteNotFoundException($"Note with id {updateNoteDto.Id} does not exist!");
            
            User userDb = _userRepository.GetById(updateNoteDto.UserId);
            if (userDb == null) throw new NoteDataException($"User with id {updateNoteDto.UserId} does not exsist!");
            if (string.IsNullOrWhiteSpace(updateNoteDto.Text)) throw new NoteDataException("The field is requird");
            if (updateNoteDto.Text.Length > 100) throw new Exception("Text cannot cantain more than 100 characters");

            // 2.Update 
            noteDb.Text = updateNoteDto.Text;
            noteDb.Priority = updateNoteDto.Priority;
            noteDb.Tag = updateNoteDto.Tag;
            noteDb.UserId = updateNoteDto.UserId;
            noteDb.User = userDb;
            _noteRepository.Update(noteDb);
        }
    }
}
