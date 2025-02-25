namespace DbContextTests.Model;

public abstract class Test
{
    public Test(){}
    public Test(List<Guid> references)
    {
        _references = references;
    }
    
    public int Id { get; set; }
    
    private readonly List<Guid> _references = [];
    public IEnumerable<Guid> References => _references.AsReadOnly();
}