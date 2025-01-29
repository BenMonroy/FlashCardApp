using System;

namespace AvaloniaApplication1.Models;

public class DeckProgress
{
    public int DeckId { get; set; }
    public DateTime LastStudied { get; set; }
    public int TotalFlashcards { get; set; }
    public int ReviewedFlashcards { get; set; }
}