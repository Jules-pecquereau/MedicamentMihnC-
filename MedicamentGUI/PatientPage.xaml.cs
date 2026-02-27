using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MedicamentGUI
{
    public partial class PatientPage : Page
    {
        public ObservableCollection<Patient> Patients { get; set; }
        private ObservableCollection<Patient> allPatients;

        public PatientPage()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            allPatients = new ObservableCollection<Patient>
            {
                new Patient { Id = 1, Nom = "Dupont", Prenom = "Jean", DateNaissance = new DateTime(1980, 5, 15), NumeroSecu = "1 80 05 75 123 456 78" },
                new Patient { Id = 2, Nom = "Martin", Prenom = "Marie", DateNaissance = new DateTime(1992, 8, 22), NumeroSecu = "2 92 08 75 234 567 89" },
                new Patient { Id = 3, Nom = "Durand", Prenom = "Pierre", DateNaissance = new DateTime(1975, 12, 10), NumeroSecu = "1 75 12 75 345 678 90" }
            };

            Patients = new ObservableCollection<Patient>(allPatients);
            PatientDataGrid.ItemsSource = Patients;
        }

        private void TxtSearchPatient_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterPatients();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterPatients();
        }

        private void FilterPatients()
        {
            string searchText = TxtSearchPatient.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                Patients.Clear();
                foreach (var patient in allPatients)
                {
                    Patients.Add(patient);
                }
            }
            else
            {
                var filtered = allPatients.Where(p =>
                    p.Nom.ToLower().Contains(searchText) ||
                    p.Prenom.ToLower().Contains(searchText) ||
                    p.NumeroSecu.Contains(searchText)
                ).ToList();

                Patients.Clear();
                foreach (var patient in filtered)
                {
                    Patients.Add(patient);
                }
            }
        }

        private void BtnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'ajout à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            if (PatientDataGrid.SelectedItem != null)
            {
                MessageBox.Show("Fonctionnalité de modification à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (PatientDataGrid.SelectedItem != null)
            {
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce patient ?", 
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Fonctionnalité de suppression à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string NumeroSecu { get; set; } = string.Empty;
    }
}
