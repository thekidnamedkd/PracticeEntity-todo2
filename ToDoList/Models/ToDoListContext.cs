using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext
  {
    public virtual DbSet<Category> Categories {get; set;} //we need virtual keyword here to enable lazy loading
    public DbSet<Item> Items { get; set; }
   

    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}
