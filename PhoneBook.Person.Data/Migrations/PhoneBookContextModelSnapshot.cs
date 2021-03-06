// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.Person.Data;

namespace PhoneBook.Person.Data.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    partial class PhoneBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.Person.Data.dbContact", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("dbContactTypeUUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("dbPersonUUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UUID");

                    b.HasIndex("dbContactTypeUUID");

                    b.HasIndex("dbPersonUUID");

                    b.ToTable("dbContact");
                });

            modelBuilder.Entity("PhoneBook.Person.Data.dbContactType", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("dbContactType");

                    b.HasData(
                        new
                        {
                            UUID = new Guid("914008df-087f-48e9-a71d-54df19d99b6c"),
                            Name = "Telefon"
                        },
                        new
                        {
                            UUID = new Guid("7f567c2f-b5b2-49d6-a896-e26fb97bf157"),
                            Name = "Email"
                        },
                        new
                        {
                            UUID = new Guid("09b56555-eda1-428b-9fc4-465bf2c63502"),
                            Name = "Location"
                        });
                });

            modelBuilder.Entity("PhoneBook.Person.Data.dbPerson", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("dbPerson");
                });

            modelBuilder.Entity("PhoneBook.Person.Data.dbContact", b =>
                {
                    b.HasOne("PhoneBook.Person.Data.dbContactType", "dbContactType")
                        .WithMany()
                        .HasForeignKey("dbContactTypeUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhoneBook.Person.Data.dbPerson", null)
                        .WithMany("dbContacts")
                        .HasForeignKey("dbPersonUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dbContactType");
                });

            modelBuilder.Entity("PhoneBook.Person.Data.dbPerson", b =>
                {
                    b.Navigation("dbContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
