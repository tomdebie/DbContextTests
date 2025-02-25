namespace DbContextTests.Model;

public class SuperTest : Test
{
    public SuperTest(){}
    public SuperTest(List<Guid> references) :base (references)
    {
    }
    
    public string Name {get;set;}
}