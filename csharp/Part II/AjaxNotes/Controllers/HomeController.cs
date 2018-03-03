using System.Collections.Generic;
using AjaxNotes.Factories;
using AjaxNotes.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxNotes.Controllers
{
    public class NotesController : Controller
    {

        private readonly NoteFactory _noteFactory;

        public NotesController(NoteFactory noteFactory)
        {
            _noteFactory = noteFactory;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [Route("notes")]
        public JsonResult AllNotes()
        {
            List<Note> AllNotes = _noteFactory.FindAll();
            return Json(AllNotes);
        }

        [HttpPost]
        [Route("newnote")]
        public JsonResult CreateNote(Note model)
        {
            if (ModelState.IsValid)
            {
                _noteFactory.Add(model);

                Note NewNote = _noteFactory.GetLatest();

                return Json(NewNote);
            }
            return Json(new { Failed = "true" });
        }

        [HttpPost]
        [Route("updatenote")]
        public void UpdateNote(Note model)
        {
            _noteFactory.Update(model);
        }

        [HttpPost]
        [Route("deletenote/{Id}")]
        public void DeleteNote(int Id)
        {
            _noteFactory.Delete(Id);
        }
    }
}