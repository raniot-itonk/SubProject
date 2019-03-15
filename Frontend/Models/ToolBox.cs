using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public class ToolBox
    {
        public long Id { get; set; }
        public DateTime Purchased { get; set; }
        public Craftsman Craftsman { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }
}