using Avenga.NoteApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.NoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
    }
}
