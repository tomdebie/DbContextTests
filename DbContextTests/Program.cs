using DbContextTests;
using DbContextTests.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
    //.ConfigureLogging(configuration =>
    //{
    //    configuration.AddConsole();
    //})
    .ConfigureServices(services =>
    {
        services.AddDbContext<TestDbContext>();
    })
    .Build();

Console.WriteLine("Recreating database!");
var context = host.Services.GetService<TestDbContext>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine("Database recreated!");

// Test to check that 
//var transaction = await context!.Database.BeginTransactionAsync();

//var blog = new Blog
//{
//    Name = "Test"
//};
//context.Add(blog);
//Console.WriteLine($"Context changes: {context.ChangeTracker.HasChanges()}");

//await transaction.RollbackAsync();


//var transaction2 = await context!.Database.BeginTransactionAsync();

//Console.WriteLine($"Context changes: {context.ChangeTracker.HasChanges()}");

//await context.SaveChangesAsync();

//await transaction2.CommitAsync();

Console.WriteLine("Start");

var blog = new Blog
{
    Name = "Test",
    Posts = []
};

var post = new Post
{
    Blog = blog,
    Name = "Haha oh well",
    Description = "Meh",
    Author = "Me",
    Paragraphs = []
};

var paragraph1 = new Paragraph
{
    Blog = blog,
    Post = post,
    Text = "Test1"
};

var paragraph2 = new Paragraph
{
    Blog = blog,
    Post = post,
    Text = "Test2"
};

post.Paragraphs.AddRange([paragraph1, paragraph2]);
blog.Posts.Add(post);
context.Add(blog);

Console.WriteLine($"Context changes: {context.ChangeTracker.HasChanges()}");
await context.SaveChangesAsync();

paragraph1.Text = "test";
paragraph2.Text = "test";
blog.Name = "Test2";
await context.SaveChangesAsync();


var test = context.Paragraphs.Where(x => x.BlogId == blog.Id).ToListAsync();

var trackedBlog = new TrackedBlog
{
    Name = "Test2",
    Posts = [],
    Source = "bloedserious",
    Medium = "email",
    Campaign = "plasma"
};
context.Add(trackedBlog);
await context.SaveChangesAsync();


var appointment = new Appointment
{
    AppointmentTime = DateTime.Now
};
context.Add(appointment);

var appointmentWithTracking = new Appointment
{
    AppointmentTime = DateTime.Now,
    Utm = new AppointmentUtm
    {
        Source = "bloedserious",
        Medium = "email",
        Campaign = "plasma"
    }
};
context.Add(appointmentWithTracking);
await context.SaveChangesAsync();


// save timeslot with extra stuff?
var plasmaRideAppointment = new AppointmentPlasmaRide()
{
    AppointmentTime = DateTime.Now,
    DepartureTime = TimeOnly.FromDateTime(DateTime.Now)
};
context.Add(plasmaRideAppointment);
await context.SaveChangesAsync();

var appointments = context.Appointments.ToList();

var appointmentsVms = context.Appointments
    .Select(x => new
    {
        x.Id,
        x.AppointmentTime,
        DepartureTime = (x is AppointmentPlasmaRide) ? (x as AppointmentPlasmaRide).DepartureTime : TimeOnly.MinValue, 
    })
    .ToList();
// Dus!

// Try to model something like a basic user (id, name) and then a billing user (id, address, bank account number)


Console.WriteLine("Done!");
