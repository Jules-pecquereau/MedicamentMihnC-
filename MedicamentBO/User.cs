namespace MedicamentBO;

public class User
{
    public string Nom { get; }
    public string Prenom { get; }
    public string Email { get; }
    public User(string nom, string prenom, string email )
    {
        Nom = nom;
        Prenom = prenom;
        Email = email;
    }

}
