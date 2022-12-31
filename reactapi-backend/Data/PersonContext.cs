using Microsoft.EntityFrameworkCore;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }
}