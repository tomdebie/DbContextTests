namespace DbContextTests.Model;

public class Paragraph
{
    public int Id { get; set; }

    public string Text { get; set; }

    public int PostId { get; set; }

    public Post Post { get; set; }

    public int BlogId { get; set; }

    public Blog Blog { get; set; }
}
