using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels
{
    public partial class DecksViewModel : PageViewModel
    {
        private readonly DeckRepository _repository; // For persistence

        public ObservableCollection<Deck> Decks { get; } // List of decks

        [ObservableProperty]
        private Deck? selectedDeck; // The currently selected deck

        [ObservableProperty]
        private bool isCreatePopupVisible; // Controls visibility of the create popup

        [ObservableProperty]
        private bool isDeletePopupVisible; // Controls visibility of the delete popup

        [ObservableProperty]
        private string newDeckName = string.Empty; // Holds the input for the new deck name

        public DecksViewModel(DeckRepository repository)
        {
            _repository = repository;
            PageName = PageNames.Decks;

            // Load decks from the repository
            Decks = new ObservableCollection<Deck>(_repository.LoadDecks());
            Decks = new ObservableCollection<Deck>
            {
                new Deck { Name = "Test Deck 1", Id = 1 },
                new Deck { Name = "Test Deck 2", Id = 2 }
            };

        }

        [RelayCommand]
        private void OpenCreatePopup()
        {
            IsCreatePopupVisible = true;
        }

        [RelayCommand]
        private void CreateDeck()
        {
            if (string.IsNullOrWhiteSpace(NewDeckName)) return;

            var newDeck = new Deck { Name = NewDeckName };
            Decks.Add(newDeck);
            _repository.SaveDecks(new ObservableCollection<Deck>(Decks)); // Persist changes

            IsCreatePopupVisible = false;
            NewDeckName = string.Empty;

            // Navigate to the new deck page
            NavigateToDeckPage(newDeck);
        }


        [RelayCommand]
        private void CancelCreate()
        {
            IsCreatePopupVisible = false;
            NewDeckName = string.Empty;
        }

        [RelayCommand]
        private void OpenDeletePopup(Deck deck)
        {
            SelectedDeck = deck;
            IsDeletePopupVisible = true;
        }

        [RelayCommand]
        private void ConfirmDelete()
        {
            if (SelectedDeck == null) return;

            Decks.Remove(SelectedDeck);
            _repository.SaveDecks(new ObservableCollection<Deck>(Decks)); // Persist changes

            IsDeletePopupVisible = false;
            SelectedDeck = null;
        }

        [RelayCommand]
        private void CancelDelete()
        {
            IsDeletePopupVisible = false;
            SelectedDeck = null;
        }

        [RelayCommand]
        private void EditDeck(Deck deck)
        {
            NavigateToDeckPage(deck);
        }

        [RelayCommand]
        private void ViewDeck(Deck deck)
        {
            NavigateToDeckPage(deck);
        }

        private void NavigateToDeckPage(Deck deck)
        {
            // Implement navigation to the deck page using the deck ID
            // This can be handled by a navigation service or ViewModel factory
        }
    }
}
