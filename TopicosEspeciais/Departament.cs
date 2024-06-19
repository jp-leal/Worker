namespace TopicosEspeciais;

class Departament
{
    public int Id { get; set; }
    public string Dept { get; set; }
    public static int idCounter = 0;

    public Departament(int Id, string Dept)
    {
        this.Id = Id;
        this.Id = idCounter++;
        
        this.Dept = Dept;
    }
}