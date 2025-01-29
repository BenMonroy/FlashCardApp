using System;

namespace AvaloniaApplication1.Models;

public class FlashCard
{
    public int Id { get; set; } // Unique identifier
    public string Front { get; set; } // Question or front side
    public string Back { get; set; } // Answer or back side
    public DateTime NextReviewDate { get; set; } // When this card should next be reviewed
    public int EaseFactor { get; set; } // Used for spaced repetition (default 250, range 130-350)
    public int ReviewCount { get; set; } // Number of times reviewed
    public bool IsDue => DateTime.Now >= NextReviewDate; // Whether this card is due
}
