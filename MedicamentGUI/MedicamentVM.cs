using MedicamentGUI.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MedicamentBO;
using MedecineApp;

namespace MedicamentGUI
{
    public class MedicamentVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly BddRepository bddRepository;
        private BibliotequeMedicament? bibliotheque;
        private List<Medicament> allMedicaments;
        private List<Medicament> filteredMedicaments;

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
                CurrentPage = 1;
                FilterMedicaments();
            }
        }

        private int currentPage = 1;
        public int CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PageInfo));
                UpdatePagedData();
            }
        }

        private int itemsPerPage = 10;
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set
            {
                itemsPerPage = value;
                OnPropertyChanged();
                CurrentPage = 1;
                UpdatePagedData();
            }
        }

        public int TotalPages => filteredMedicaments == null || filteredMedicaments.Count == 0 
            ? 1 
            : (int)Math.Ceiling((double)filteredMedicaments.Count / ItemsPerPage);

        public string PageInfo => $"Page {CurrentPage} sur {TotalPages} ({filteredMedicaments?.Count ?? 0} médicament(s))";

        public bool CanGoPrevious => CurrentPage > 1;
        public bool CanGoNext => CurrentPage < TotalPages;

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand FirstPageCommand { get; }
        public ICommand LastPageCommand { get; }

        public MedicamentVM()
        {
            bddRepository = new BddRepository();
            allMedicaments = new List<Medicament>();
            filteredMedicaments = new List<Medicament>();

            AddCommand = new RelayCommand(_ => AddMedicament());
            EditCommand = new RelayCommand(_ => EditMedicament(), _ => SelectedMedicament is not null);
            DeleteCommand = new RelayCommand(_ => DeleteMedicament(), _ => SelectedMedicament is not null);
            SearchCommand = new RelayCommand(_ => FilterMedicaments());
            RefreshCommand = new RelayCommand(_ => LoadMedicaments());
            PreviousPageCommand = new RelayCommand(_ => PreviousPage(), _ => CanGoPrevious);
            NextPageCommand = new RelayCommand(_ => NextPage(), _ => CanGoNext);
            FirstPageCommand = new RelayCommand(_ => FirstPage(), _ => CanGoPrevious);
            LastPageCommand = new RelayCommand(_ => LastPage(), _ => CanGoNext);

            LoadMedicaments();
        }

        private void LoadMedicaments()
        {
            try
            {
                bibliotheque = bddRepository.BuildBibliothequeMedicaments();
                allMedicaments = bibliotheque.AfficherAllMedicament().ToList();
                CurrentPage = 1;
                FilterMedicaments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des médicaments : {ex.Message}", 
                    "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterMedicaments()
        {
            filteredMedicaments.Clear();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredMedicaments = allMedicaments.ToList();
            }
            else
            {
                filteredMedicaments = allMedicaments.Where(m =>
                    m.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    m.Laboratory.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    m.Code_Medicament.ToString().Contains(SearchText)
                ).ToList();
            }

            OnPropertyChanged(nameof(TotalPages));
            OnPropertyChanged(nameof(PageInfo));
            OnPropertyChanged(nameof(CanGoPrevious));
            OnPropertyChanged(nameof(CanGoNext));
            UpdatePagedData();
        }

        private void UpdatePagedData()
        {
            Medicaments.Clear();

            var itemsToSkip = (CurrentPage - 1) * ItemsPerPage;
            var pagedItems = filteredMedicaments.Skip(itemsToSkip).Take(ItemsPerPage);

            foreach (var med in pagedItems)
            {
                Medicaments.Add(med);
            }

            OnPropertyChanged(nameof(CanGoPrevious));
            OnPropertyChanged(nameof(CanGoNext));
        }

        private void PreviousPage()
        {
            if (CanGoPrevious)
            {
                CurrentPage--;
            }
        }

        private void NextPage()
        {
            if (CanGoNext)
            {
                CurrentPage++;
            }
        }

        private void FirstPage()
        {
            CurrentPage = 1;
        }

        private void LastPage()
        {
            CurrentPage = TotalPages;
        }

        private void AddMedicament()
        {
            MessageBox.Show("Fonctionnalité d'ajout à implémenter dans BddRepository", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditMedicament()
        {
            if (SelectedMedicament is not null)
            {
                MessageBox.Show("Fonctionnalité de modification à implémenter dans BddRepository", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteMedicament()
        {
            if (SelectedMedicament is not null)
            {
                var result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer '{SelectedMedicament.Name}' ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Fonctionnalité de suppression à implémenter dans BddRepository", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
