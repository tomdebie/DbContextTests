namespace DbContextTests.Model;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }

    private readonly List<Post> _posts = [];
    public IEnumerable<Post> Posts => _posts.AsReadOnly();

    public void AddPost(Post post)
    {
        _posts.Add(post);
    }
    
    //public TrackedBlog TrackingInformation { get; set; }
}
