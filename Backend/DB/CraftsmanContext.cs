using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.DB
{
    public class CraftsmanContext : DbContext
    {
        public CraftsmanContext(DbContextOptions<CraftsmanContext> options)
            : base(options)
        {
        }
        public DbSet<Craftsman> Craftsmen { get; set; }
        public DbSet<ToolBox> ToolBoxes { get; set; }
        public DbSet<Tool> Tools { get; set; }
    }


    public class Craftsman
    {
        public long Id { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string LastName { get; set; }
        public string SubjectArea { get; set; }
        public string FirstName { get; set; }
        public ICollection<ToolBox> ToolBoxes { get; set; }
    }

    public class ToolBox
    {
        public long Id { get; set; }
        public DateTime Purchased { get; set; }
        [ForeignKey("Craftsman")]
        public long CraftsmanId { get; set; }
        public Craftsman Craftsman { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }

    public class Tool
    {
        public long Id { get; set; }
        public DateTime Purchased { get; set; }
        public string Product { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        [ForeignKey("ToolBox")]
        public long ToolBoxId { get; set; }
        public ToolBox ToolBox { get; set; }
    }
}
