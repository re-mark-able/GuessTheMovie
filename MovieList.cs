using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheMovie
{
    public class MovieResult
    {
        public int page { get; set; }
        public List<MovieList>? results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }


    }
    public class MovieList
    {

        public bool adult { get; set; }
        public string? backdrop_path { get; set; }
        public int[]? genre_ids { get; set; }
        public string? name { get; set; }
        public string? first_air_date { get; set; }
        public int id { get; set; }
        public string? original_language { get; set; }

        public string? original_title { get; set; }
        public string? overview { get; set; }
        public float? popularity { get; set; }
        public string? poster_path { get; set; }
        public string? release_date { get; set; }
        public string title { get; set; }
        public bool? video { get; set; }
        public float? vote_average { get; set; }
        public int? vote_count { get; set; }

    }
}
