using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxNotes.Models
{
    public class Note : BaseEntity
    {
        public int NoteId { get; set; }

        [Required]
        public string NoteTitle { get; set; }

        public string NoteContent { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}