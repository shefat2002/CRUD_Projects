using Microsoft.EntityFrameworkCore;
using SortFilterPagination.Models;

namespace SortFilterPagination.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> People => Set<Person>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var firstNames = new[] { "John", "Emma", "Michael", "Sarah", "James", "Olivia", "Robert", "Sophia", "William", "Isabella", "David", "Mia", "Richard", "Charlotte", "Joseph", "Amelia", "Thomas", "Harper", "Charles", "Evelyn", "Daniel", "Abigail", "Matthew", "Emily", "Anthony", "Elizabeth", "Mark", "Sofia", "Donald", "Avery", "Steven", "Ella", "Paul", "Madison", "Andrew", "Scarlett", "Joshua", "Victoria", "Kenneth", "Aria", "Kevin", "Grace", "Brian", "Chloe", "George", "Camila", "Timothy", "Penelope", "Ronald", "Riley" };
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts" };
        var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "Charlotte", "San Francisco", "Indianapolis", "Seattle", "Denver", "Boston", "Nashville", "Detroit", "Portland", "Memphis", "Oklahoma City", "Las Vegas", "Louisville", "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Fresno", "Mesa", "Sacramento", "Atlanta", "Kansas City", "Colorado Springs", "Miami", "Raleigh", "Omaha", "Long Beach", "Virginia Beach", "Oakland", "Minneapolis", "Tulsa", "Tampa", "Arlington", "New Orleans", "Wichita", "Cleveland" };

        var people = new List<Person>();
        var random = new Random(42);

        for (int i = 1; i <= 1500; i++)
        {
            var firstName = firstNames[random.Next(firstNames.Length)];
            var lastName = lastNames[random.Next(lastNames.Length)];
            people.Add(new Person
            {
                Id = i,
                FirstName = firstName,
                LastName = lastName,
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}{i}@email.com",
                Age = random.Next(18, 65),
                City = cities[random.Next(cities.Length)]
            });
        }

        modelBuilder.Entity<Person>().HasData(people);
    }
}
