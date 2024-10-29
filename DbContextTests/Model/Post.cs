namespace DbContextTests.Model;

public class Post
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public List<Paragraph> Paragraphs {  get; set; }
}
