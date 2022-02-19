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
context.Table3.Add(new Table3 { Id = 1, Value = "Montenegro" });
context.Table3.Add(new Table3 { Id = 2, Value = "Albania" });
context.Table3.Add(new Table3 { Id = 3, Value = "Hungary" });
context.Table4.Add(new Table4 { Id = 1, Value = new DateTime(2021, 1, 1) });
context.Table4.Add(new Table4 { Id = 2, Value = new DateTime(1961, 4, 12) });
context.Table4.Add(new Table4 { Id = 3, Value = new DateTime(1986, 4, 26) });
context.Table5.Add(new Table5() { Id = 1, Value = 23 });
context.Table6.Add(new Table6() { Id = "Key", Value = 42 });
context.SaveChanges();
var query = context.Table2.Where(i => i.Value == 2);
var list = query.ToList();
foreach (var item in list)
{
    Console.WriteLine($"Found id: {item.Id}");
}

foreach (var item in context.Table3.Where(i => i.Id > 2).ToList())
{
    Console.WriteLine($"Found id: {item.Value}");
}

foreach (var item in context.Table4.Where(i => i.Id > 2).ToList())
{
    Console.WriteLine($"Chernobyl: {item.Value}");
}

foreach (var item in context.Table5.Where(i => i.Id == 1).ToList())
{
    Console.WriteLine($"Found value: {item.Value}");
}

foreach (var item in context.Table6.Where(i => i.Id == "Key").ToList())
{
    Console.WriteLine($"Answer to all questions: {item.Value}");
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
public class Table3
{
    public int Id { get; set; }
    public string Value { get; set; }
}
public class Table4
{
    public int Id { get; set; }
    public DateTime Value { get; set; }
}
public class Table5
{
    public int Id { get; set; }
    public long Value { get; set; }
}
public class Table6
{
    public string Id { get; set; }
    public long Value { get; set; }
}
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    
    public DbSet<Table1> Table1 { get; set; } = default!;
    public DbSet<Table2> Table2 { get; set; } = default!;
    public DbSet<Table3> Table3 { get; set; } = default!;
    public DbSet<Table4> Table4 { get; set; } = default!;
    public DbSet<Table5> Table5 { get; set; } = default!;
    public DbSet<Table6> Table6 { get; set; } = default!;
}
