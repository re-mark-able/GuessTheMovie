using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheMovie
{
    public class MovieItem
    {
        public string? Title { get; set;  }
        public string? MaskedTitle { get; set; }
        public string? Year { get; set; }
        public string? Plot { get; set; }
        public string? Image { get; set; }
        public string? Guess { get; set; }
        public bool? Answered { get; set; }
        public string? Result { get; set; }
        public override string ToString()
        {
            return Title ?? "";
        }
    }
}
