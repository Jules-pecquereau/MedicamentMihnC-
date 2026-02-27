namespace MedicamentBO;

public class Medicament
{
    public int Code_Medicament { get; set; }
    public string Name { get; set; }
    public string Laboratory { get; set; }

    public Medicament(int code_Medicament, string name, string laboratory)
    {
        Code_Medicament = code_Medicament;
        Name = name;
        Laboratory = laboratory;
    }

    public override string ToString()
    {
        return $"Code: {Code_Medicament}, Name: {Name}, Laboratory: {Laboratory}";
    }

}
