using MedicamentGUI.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MedicamentGUI
{
    public class Medicament
    {
        public long CodeMedicament { get; set; }
        public string Designation { get; set; } = string.Empty;
        public string Laboratoire { get; set; } = string.Empty;
    }

    public class MedicamentVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Medicament> allMedicament;
        public ObservableCollection<Medicament> Medicaments { get; set; } = new ObservableCollection<Medicament>();

        private Medicament? selectedMedicament;
        public Medicament? SelectedMedicament
        {
            get => selectedMedicament;
            set
            {
                selectedMedicament = value;
                OnPropertyChanged();
            }
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
                FilterMedicaments();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public MedicamentVM()
        {
            allMedicament = new ObservableCollection<Medicament>();

            AddCommand = new RelayCommand(_ => AddMedicament());
            EditCommand = new RelayCommand(_ => EditMedicament(), _ => SelectedMedicament is not null);
            DeleteCommand = new RelayCommand(_ => DeleteMedicament(), _ => SelectedMedicament is not null);
            SearchCommand = new RelayCommand(_ => FilterMedicaments());

            LoadMedicament();
        }

        private void LoadMedicament()
        {
            allMedicament = new ObservableCollection<Medicament>
            {
                new Medicament { CodeMedicament = 3400930001134, Designation = "DOLIPRANE 1000MG", Laboratoire = "SANOFI" },
                new Medicament { CodeMedicament = 3400935526243, Designation = "ASPIRINE UPSA 500MG", Laboratoire = "UPSA" },
                new Medicament { CodeMedicament = 3400936244900, Designation = "IBUPROFENE BIOGARAN 400MG", Laboratoire = "BIOGARAN" }
            };

            FilterMedicaments();
        }

        private void FilterMedicaments()
        {
            Medicaments.Clear();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                foreach (var med in allMedicament)
                {
                    Medicaments.Add(med);
                }
            }
            else
            {
                var filtered = allMedicament.Where(m =>
                    m.Designation.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    m.Laboratoire.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    m.CodeMedicament.ToString().Contains(SearchText)
                );

                foreach (var med in filtered)
                {
                    Medicaments.Add(med);
                }
            }
        }

        private void AddMedicament()
        {
            MessageBox.Show("Fonctionnalité d'ajout à implémenter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditMedicament()
        {
            if (SelectedMedicament is not null)
            {
                MessageBox.Show($"Modification de : {SelectedMedicament.Designation}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteMedicament()
        {
            if (SelectedMedicament is not null)
            {
                var result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer '{SelectedMedicament.Designation}' ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    allMedicament.Remove(SelectedMedicament);
                    FilterMedicaments();
                    MessageBox.Show("Médicament supprimé avec succès", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
