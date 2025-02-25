namespace DbContextTests.Model;

public class SuperTest : Test
{
    public SuperTest(){}
    public SuperTest(List<Guid> references) :base (references)
    {
    }
    
    public string Name {get;set;}
    
    public DateTime ModifiedOn {get;set;}

    public void RemoveReferenceAt(int index)
    {
        _references.RemoveAt(index);
    }
}