using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Programmer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
