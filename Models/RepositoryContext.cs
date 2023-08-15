using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext  //veri tabanını temsil eder, indirdiğimiz nugeti kullandı yani o şart
    //artık bu classı veri tabanı gibi düşünecez
    //DbContext kalıtım ile RepositoryContexte devraldı
    {
        public DbSet<Product> Products { get; set; }

        //*** normalde default olarak construct tanımlanır ama eğer başka construct tanımlanırsa default construct iptal olur 
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        
        //overide dedi sonra ctrl + space ile OnModelCreating i seçti
        protected override void OnModelCreating(ModelBuilder modelBuilder)  //protected, sadece kalıtım ile alınabilen bir özellik için kullanılıyor
        {
            base.OnModelCreating(modelBuilder);
            //base = DBContext
            modelBuilder.Entity<Product>()  //üzerinden çalışılmak istenen varlık : Product ,HasData : metod
            .HasData(   //birden fazla product tanımı yapılabilir
                new Product() { ProductId = 1, ProductName = "Computer", Price = 17_000 },  //bu bir çekirdek data
                new Product() { ProductId = 2, ProductName = "Keyboard", Price = 1_000 },
                new Product() { ProductId = 3, ProductName = "Mause", Price = 500 },
                new Product() { ProductId = 4, ProductName = "Monitor", Price = 7_000 },
                new Product() { ProductId = 5, ProductName = "Deck", Price = 1_500 }

            );
        }
    }
}