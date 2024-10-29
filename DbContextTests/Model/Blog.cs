namespace DbContextTests.Model;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Post> Posts { get; set; }

    //public TrackedBlog TrackingInformation { get; set; }
}
