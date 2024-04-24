using System.Collections.Generic;
using System.Linq;
using LoginApp.Data.Models;
using LoginApp.Data;
using LoginApp.Data.Models;

namespace LoginApp.Data
{
    public class SickNoteService
    {
        private readonly ApplicationDbContext _context;

        public SickNoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSickNote(string name, string reason)
        {
            var sickNote = new SickNote { Name = name, Reason = reason };
            _context.SickNotes.Add(sickNote);
            _context.SaveChanges();
        }

        public List<SickNote> GetSickNotes()
        {
            return _context.SickNotes.ToList();
        }

        public void RemoveSickNote(string name)
        {
            var sickNote = _context.SickNotes.FirstOrDefault(note => note.Name == name);
            if (sickNote != null)
            {
                _context.SickNotes.Remove(sickNote);
                _context.SaveChanges();
            }
        }
    }
}
