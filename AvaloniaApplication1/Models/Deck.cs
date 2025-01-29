using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public class Deck
{
    public int Id { get; set; } = -1; // Default to an invalid ID to signal uninitialized state
    public required string Name { get; set; } // Deck name, required for instantiation
    public List<FlashCard> Flashcards { get; set; } = new(); // Collection of flashcards

    public override string ToString()
    {
        return $"Deck: {Name}, ID: {Id}, Flashcards: {Flashcards.Count}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Deck deck && Id == deck.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}