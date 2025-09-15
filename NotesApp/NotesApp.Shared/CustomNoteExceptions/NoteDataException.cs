namespace NotesApp.Shared.CustomNoteExceptions
{
    public class NoteDataException : Exception
    {
        public NoteDataException(string message) : base(message) { }
    }
}
