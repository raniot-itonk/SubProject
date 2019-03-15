using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public class Craftsman
    {
        public long Id { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string LastName { get; set; }
        public string SubjectArea { get; set; }
        public string FirstName { get; set; }
        public ICollection<ToolBox> ToolBoxes { get; set; }
    }
}