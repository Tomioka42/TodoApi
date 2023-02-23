using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TodosModel> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodosModel>().HasData(new TodosModel()
            {
                Id = 1,
                Title = "Homework",
                Description = "Essay about world war 1",
            }, new TodosModel
            {
                Id = 2,
                Title = "Shopping",
                Description = "Buy some food for the house"
            }, new TodosModel
            {
                Id = 3,
                Title = "Homework 2",
                Description = "Essay about 'stockholms stökigaste bollo'"
            });

        }
    }
}
