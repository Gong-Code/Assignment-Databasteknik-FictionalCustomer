using DataModel.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
    public class Assignment
    {
        public int Id { get; set; }
       
        public List<Programmer> Programmer { get; set; } = new List<Programmer>();
        
        [Required]
        public string Task { get; set; }

        public WorkType WorkType { get; set; }

    }
}
