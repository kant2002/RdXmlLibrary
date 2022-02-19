using Microsoft.EntityFrameworkCore;

Console.WriteLine("Building options");
var builder = new DbContextOptionsBuilder<MyDbContext>();
builder.UseSqlite("DataSource=test.db");
var options = builder.Options;

Console.WriteLine("Creating context");
var context = new MyDbContext(options);
Console.WriteLine("Recreate database");
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine("Creating test data!");
//context.Table1.Add(new Table1() { Id = 1 });
context.Table2.Add(new Table2() { Id = 1, Value = 2 });
context.SaveChanges();
var query = context.Table2.Where(i => i.Value == 2);
var list = query.ToList();
foreach (var item in list)
{
    Console.WriteLine($"Found id: {item.Id}");
}

public class Table1
{
    public int Id { get; set; }
}
public class Table2
{
    public int Id { get; set; }
    public int Value { get; set; }
}
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    
    public DbSet<Table1> Table1 { get; set; } = default!;
    public DbSet<Table2> Table2 { get; set; } = default!;
}
