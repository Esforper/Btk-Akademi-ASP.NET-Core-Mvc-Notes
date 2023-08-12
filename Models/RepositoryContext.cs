using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext  //veri tabanını temsil eder, indirdiğimiz nugeti kullandı yani o şart
    //artık bu classı veri tabanı gibi düşünecez
    {
        public DbSet<Product> Products { get; set; }  

        //*** normalde default olarak construct tanımlanır ama eğer başka construct tanımlanırsa default construct iptal olur 
        public RepositoryContext(DbContextOptions<RepositoryContext> options) :base(options)
        {
            
        }
    }
}