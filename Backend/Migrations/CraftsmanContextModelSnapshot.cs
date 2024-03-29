﻿// <auto-generated />
using System;
using Backend.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(CraftsmanContext))]
    partial class CraftsmanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.DB.Craftsman", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfEmployment");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("SubjectArea");

                    b.HasKey("Id");

                    b.ToTable("Craftsmen");
                });

            modelBuilder.Entity("Backend.DB.Tool", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model");

                    b.Property<string>("Product");

                    b.Property<DateTime>("Purchased");

                    b.Property<string>("SerialNumber");

                    b.Property<long>("ToolBoxId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ToolBoxId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("Backend.DB.ToolBox", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<long>("CraftsmanId");

                    b.Property<string>("Model");

                    b.Property<DateTime>("Purchased");

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.ToTable("ToolBoxes");
                });

            modelBuilder.Entity("Backend.DB.Tool", b =>
                {
                    b.HasOne("Backend.DB.ToolBox", "ToolBox")
                        .WithMany("Tools")
                        .HasForeignKey("ToolBoxId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DB.ToolBox", b =>
                {
                    b.HasOne("Backend.DB.Craftsman", "Craftsman")
                        .WithMany("ToolBoxes")
                        .HasForeignKey("CraftsmanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
