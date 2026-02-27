namespace MedicamentBO;

public class BibliotequeMedicament
{
    public string Nom { get; set; }
    private List<Medicament> Medicaments = new List<Medicament>();

    public IEnumerable<Medicament> LesMedicaments { get => Medicaments; }

    public BibliotequeMedicament(string nom)
    {
        Nom = nom;
    }

    public IEnumerable<Medicament> RechercherMedicament(string nom)
    {
        if (!Medicaments.Any(m => m.Name.Contains(nom, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ExeptionRechercheMedicament($"Aucun médicament trouvé avec le nom '{nom}'.");
        }
        return Medicaments.Where(m => m.Name.Contains(nom, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Medicament> RechercherParLaboratoire(string laboratoire)
    {
        if (!Medicaments.Any(m => m.Laboratory.Contains(laboratoire, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ExeptionRechercheMedicament($"Aucun médicament trouvé du laboratoire '{laboratoire}'.");
        }
        return Medicaments.Where(m => m.Laboratory.Contains(laboratoire, StringComparison.OrdinalIgnoreCase));
    }
    public IEnumerable<Medicament> AfficherAllMedicament()
    {
        HashSet<Medicament> seen = new HashSet<Medicament>();
        foreach (var medicament in Medicaments)
        {
            seen.Add(medicament);
        }
        return seen;
        
    }

    public void AjouterMedicament(Medicament medicament)
    {
        Medicaments.Add(medicament);
    }
}
