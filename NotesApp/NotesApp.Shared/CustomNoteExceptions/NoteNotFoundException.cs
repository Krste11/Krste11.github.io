namespace NotesApp.Shared.CustomNoteExceptions
{
    public class NoteNotFoundException : Exception
    {
        public NoteNotFoundException(string message) : base(message) { }
    }
}
