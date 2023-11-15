using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.DBContext
{
    public class CustumerCosultationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Support> Supports { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }

        public CustumerCosultationContext(DbContextOptions<CustumerCosultationContext> options) : base(options)//Acá estamos llamando al constructor de DbContext que es el que acepta las opciones)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType); //discrimina el usuario segun tipodeRol

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    LastName = "Elena",
                    Name = "Maria Celia",
                    Email = "mcelena@gmail.com",
                    UserName = "nbologna",
                    Password = "123456",
                    Id = 1
                },
                new Customer
                {
                    LastName = "Cura",
                    Name = "Azul",
                    Email = "acura@gmail.com",
                    UserName = "acura",
                    Password = "123456",
                    Id = 2
                },
                new Customer
                {
                    LastName = "Guarde",
                    Name = "Santiago",
                    Email = "sguarde@gmail.com",
                    UserName = "sguarde",
                    Password = "123456",
                    Id = 3
                });

            modelBuilder.Entity<Support>().HasData(
                new Support
                {
                    LastName = "Cristofanelli",
                    Name = "Lucia",
                    Email = "lcristofanelli@gmail.com",
                    UserName = "lcristofanelli",
                    Password = "123456",
                    Id = 4
                },
                new Support
                {
                    LastName = "Curcio",
                    Name = "Melani",
                    Email = "mcurcio@gmail.com",
                    UserName = "mcurcio",
                    Password = "123456",
                    Id = 5
                });

            modelBuilder.Entity<Consultation>() // relación Consulta con Respuesta
            .HasMany(c => c.Responses) // muchas respuestas
            .WithOne(r => r.Consultation) //un respuesta
            .HasForeignKey(r => r.ConsultationId) // consulta - naranja
            .HasForeignKey(r => r.CreatorId); // user - naranja


            modelBuilder.Entity<Consultation>() // relación C con Soporte
                .HasOne(c => c.AssignedSupport) // una persona de soporte
                .WithMany() // soporte tiene varias C
                .HasForeignKey(c => c.AssignedSupportId); // C tiene soporteId 

            modelBuilder.Entity<Consultation>() // relación C con cliente
                .HasOne(c => c.Customer) // un cliente 
                .WithMany() // cliente tiene varias C
                .HasForeignKey(c => c.CreatorCustomerId); // C tiene clienteId 

            base.OnModelCreating(modelBuilder);
        }






    }
}
