using System;

namespace Frontend.Models
{
    public class Tool
    {
        public long Id { get; set; }
        public DateTime Purchased { get; set; }
        public string Product { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public ToolBox ToolBox { get; set; }
    }
}