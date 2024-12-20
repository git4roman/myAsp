using Microsoft.EntityFrameworkCore;
using MyAsp.Models;

namespace MyAsp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "AI", Description = "Artificial Intelligence" },
            new Category { Id = 2, Name = "ML", Description = "Machine Learning" },
            new Category { Id = 3, Name = "Data Science", Description = "Analysis of large data sets" },
            new Category { Id = 4, Name = "Web Development", Description = "Building and maintaining websites" },
            new Category { Id = 5, Name = "Mobile Development", Description = "Developing mobile applications" },
            new Category { Id = 6, Name = "DevOps", Description = "Development and operations practices" },
            new Category { Id = 7, Name = "Cybersecurity", Description = "Protecting systems and data" },
            new Category { Id = 8, Name = "Cloud Computing", Description = "Using cloud-based infrastructure" },
            new Category { Id = 9, Name = "IoT", Description = "Internet of Things devices and systems" },
            new Category { Id = 10, Name = "Blockchain", Description = "Decentralized ledger technology" },
            new Category { Id = 11, Name = "Game Development", Description = "Creating video games" },
            new Category { Id = 12, Name = "UI/UX Design", Description = "Designing user interfaces and experiences" },
            new Category { Id = 13, Name = "Embedded Systems", Description = "Programming hardware devices" },
            new Category { Id = 14, Name = "AR/VR", Description = "Augmented and Virtual Reality technologies" },
            new Category { Id = 15, Name = "Big Data", Description = "Handling massive amounts of data" },
            new Category { Id = 16, Name = "Robotics", Description = "Design and operation of robots" },
            new Category { Id = 17, Name = "Software Testing", Description = "Ensuring software quality" },
            new Category { Id = 18, Name = "Networking", Description = "Connecting computers and devices" },
            new Category { Id = 19, Name = "Digital Marketing", Description = "Promoting products online" },
            new Category { Id = 20, Name = "E-Commerce", Description = "Online buying and selling" }
            );

        }
    }
}
