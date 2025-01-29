using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Data
{
    public class DeckRepository
    {
        private const string FilePath = "decks.json"; // File to store decks

        public ObservableCollection<Deck> LoadDecks()
        {
            if (!File.Exists(FilePath))
            {
                // Return an empty list if the file doesn't exist
                return new ObservableCollection<Deck>();
            }

            try
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<ObservableCollection<Deck>>(json) ?? new ObservableCollection<Deck>();
            }
            catch
            {
                // Handle potential deserialization issues
                return new ObservableCollection<Deck>();
            }
        }

        public void SaveDecks(ObservableCollection<Deck> decks)
        {
            try
            {
                var json = JsonSerializer.Serialize(decks, new JsonSerializerOptions
                {
                    WriteIndented = true // Pretty-print JSON for readability
                });
                File.WriteAllText(FilePath, json);
            }
            catch
            {
                // Handle potential file I/O issues
                // Log or display an error message as appropriate
            }
        }

        public void AddDeck(Deck deck)
        {
            var decks = LoadDecks();
            decks.Add(deck);
            SaveDecks(decks);
        }

        public void RemoveDeck(Deck deck)
        {
            var decks = LoadDecks();
            var deckToRemove = decks.FirstOrDefault(d => d.Id == deck.Id);
            if (deckToRemove != null)
            {
                decks.Remove(deckToRemove);
                SaveDecks(decks);
            }
        }
    }
}