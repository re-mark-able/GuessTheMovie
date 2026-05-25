using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheMovie
{
    public class User
    {
        public int Answered { get; set; } = 0;
        public int Correct { get; set; } = 0;
        public int CurrentNumber { get; set; } = 0;
        public DateTime StartTime { get; set; } = new DateTime();
        public bool Movies { get; set; } = true;
        public bool LastCorrect { get; set; } = false;
        public bool KidFriendly { get; set; } = false;
        public List<MovieList>? MovieList { get; set; } = new();
        public MovieItem? CurrentItem { get; set; } = new();
        public bool NewQuestion { get; set;  } = true;
        public List<Result>? Results { get; set; } = new();
        // best time
        // start time
    }

    public class Result
    {
        public required int Id { get; set; }
        public required string Guess { get; set; }
        public required string Answer { get; set; }
        public int Time { get; set; } = 0;
        public bool Skipped { get; set; } = false;
        public bool Correct { get; set; } = false;
        public string Image { get; set; } = "";
        public string ResultText { get; set; } = "Incorrect";
        public string ResultTextColor { get; set; } = "DarkRed";
    }

}
