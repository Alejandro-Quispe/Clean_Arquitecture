using Microsoft.EntityFrameworkCore;
using Norwind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class NorthWindContext : DbContext
    {

        // Constructor
        // pasamos al construtor ---->  base(options) 

        public NorthWindContext(DbContextOptions<NorthWindContext> options) :
            base(options) { }

        // POCO Entities creamos db set de (Customer,Order Order Detalis , producto
        // entidades
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }


        // especificamos las reglas validacion a los datos de las entidades


        protected override void OnModelCreating(
            ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Customer>()
                    .Property(c => c.Id)
                    .HasMaxLength(5)
                    .IsFixedLength();


            modelBuilder.Entity<Customer>()
                    .Property(c => c.Name)
                    .IsRequired()  // NO ACEPTA NULOS
                    .HasMaxLength(40); // SOLO ACEPTA 40 CARACR¿TERES


            // PRODUCTO

                    modelBuilder.Entity<Product>()
                    .Property(p=>p.Name)
                    .IsRequired()  // NO ACEPTA NULOS
                    .HasMaxLength(40); // SOLO ACEPTA 40 CARACR¿TERES

                    modelBuilder.Entity<Order>()
                    .Property(o => o.customerId)
                    .IsRequired()  // NO ACEPTA NULOS
                    .HasMaxLength(5) // SOLO ACEPTA 5 CARACR¿TERES
                    .IsFixedLength();

                    modelBuilder.Entity<Order>()
                    .Property(o => o.ShipAddress)
                    .IsRequired()  // NO ACEPTA NULOS
                    .HasMaxLength(60); // SOLO ACEPTA 60 CARACR¿TERES


            modelBuilder.Entity<Order>()
            .Property(o => o.ShipCity)
            .IsRequired()  // NO ACEPTA NULOS
            .HasMaxLength(15); // SOLO ACEPTA 15 CARACR¿TERES


            modelBuilder.Entity<Order>()
                      .Property(o => o.ShipCountry)
                      .IsRequired()  // NO ACEPTA NULOS
                      .HasMaxLength(15); // SOLO ACEPTA 15 CARACR¿TERES


            modelBuilder.Entity<Order>()
          .Property(o => o.ShipPostalCode)
          .IsRequired()  // NO ACEPTA NULOS
          .HasMaxLength(10); // SOLO ACEPTA 10 CARACR¿TERES


            modelBuilder.Entity<OrderDetail>()
                // uniendo las entidades por las siguientes llaves
            .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<Order>()
            .HasOne<Customer>()
            .WithMany() // se realaciona a muchos
            .HasForeignKey(o => o.customerId); // tomando como llave foreana producto id


            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany() // se realaciona a muchos
                .HasForeignKey(od => od.ProductId); // tomando como llave foreana producto id


            // agregar datos de prueba

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ID=1,Name="Chai"},
                new Product { ID=2,Name="Chang" },
                new Product { ID =3, Name = "Anissed Syrup" }
                );


            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id = "ALFKI",Name="Alfreds ds." },
                new Customer { Id = "ANATR", Name = "Ana trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );


        }



    }
}
