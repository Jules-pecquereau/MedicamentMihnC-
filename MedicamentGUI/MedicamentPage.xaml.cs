using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MedicamentGUI
{
    public partial class MedicamentPage : Page
    {
        public ObservableCollection<Medicament> Medicaments { get; set; }
        private ObservableCollection<Medicament> allMedicaments;

        public MedicamentPage()
        {
            InitializeComponent();
            LoadMedicaments();
        }

        private void LoadMedicaments()
        {
            allMedicaments = new ObservableCollection<Medicament>
            {
                new Medicament { Id = 1, Nom = "Doliprane", Description = "Paracétamol 1000mg", Prix = 3.50m, Stock = 100 },
                new Medicament { Id = 2, Nom = "Aspirine", Description = "Acide acétylsalicylique 500mg", Prix = 2.80m, Stock = 150 },
                new Medicament { Id = 3, Nom = "Ibuprofène", Description = "Anti-inflammatoire 400mg", Prix = 4.20m, Stock = 80 }
            };

            Medicaments = new ObservableCollection<Medicament>(allMedicaments);
            MedicamentDataGrid.ItemsSource = Medicaments;
        }

        private void TxtSearchMedicament_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterMedicaments();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterMedicaments();
        }

        private void FilterMedicaments()
        {
            string searchText = TxtSearchMedicament.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                Medicaments.Clear();
                foreach (var med in allMedicaments)
                {
                    Medicaments.Add(med);
                }
            }
            else
            {
                var filtered = allMedicaments.Where(m =>
                    m.Nom.ToLower().Contains(searchText) ||
                    m.Description.ToLower().Contains(searchText)
                ).ToList();

                Medicaments.Clear();
                foreach (var med in filtered)
                {
                    Medicaments.Add(med);
                }
            }
        }

        private void BtnAddMedicament_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'ajout à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnEditMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentDataGrid.SelectedItem != null)
            {
                MessageBox.Show("Fonctionnalité de modification à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un médicament", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeleteMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentDataGrid.SelectedItem != null)
            {
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce médicament ?", 
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Fonctionnalité de suppression à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un médicament", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class Medicament
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int Stock { get; set; }
    }
}
