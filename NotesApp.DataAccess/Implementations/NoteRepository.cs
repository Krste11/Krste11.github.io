using Microsoft.EntityFrameworkCore;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Implementations
{
    public class NoteRepository : IRepository<Note>
    {
        private NotesAppDbContext _notesAppDbContext;
        public NoteRepository(NotesAppDbContext notesAppDbContext)
        {
             _notesAppDbContext = notesAppDbContext;
        }

        public List<Note> GetAll()
        {
            return _notesAppDbContext.Notes.Include(x => x.User).ToList();
        }
        public Note GetById(int id)
        {
            return _notesAppDbContext.Notes.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }
        public void Add(Note entity)
        {
            _notesAppDbContext.Notes.Add(entity);
            _notesAppDbContext.SaveChanges();
        }
        public void Update(Note entity)
        {
            _notesAppDbContext.Notes.Update(entity);
            _notesAppDbContext.SaveChanges();
        }
        public void Delete(Note entity)
        {
            _notesAppDbContext.Notes.Remove(entity);
            _notesAppDbContext.SaveChanges();
        }
    }
}
