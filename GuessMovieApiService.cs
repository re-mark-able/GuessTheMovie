using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using GuessTheMovie;


namespace GuessTheMovie
{

    public class MovieApiService
    {



        HttpClient _client = new HttpClient(new SocketsHttpHandler
        {
            // Automatically handles gzip, deflate, and br decompression
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
        });
        
        // Choose a random page to help speed up

        // Get a movie from API
        // Display the blurb
        const string apiToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4ZTkxMDE0YjRiMWI0YTgwMWU3NGZjY2MyMWM5NGZlMyIsIm5iZiI6MTcxNzgzMDg2OC44ODYwMDAyLCJzdWIiOiI2NjY0MDRkNDNjYjkyOTg2ZGE4MjU3YjkiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.zTPdJ8Alunsd11dK6GxMl3sA1mJ7gaSBONYW3Mkdk1s";


      

        public async Task<List<MovieList>> GetMovie(bool guessMovie = true)
        {
            User user = DependencyService.Get<User>();
            int pageNum = user.KidFriendly ? new Random().Next(1,20) : new Random().Next(1, 100);
            string gameMode = guessMovie == true ? "movie" : "tv";
            string modeValues = guessMovie == true ? "1|2|3" : "6";
            string apiUrl = $"https://api.themoviedb.org/3/discover/{gameMode}?without_keywords=sex|kkk|porn&include_adult=false&include_video=false&language=en-US&page={pageNum}&region=US&watch_region=US&sort_by=popularity.desc&with_original_language=en&with_release_type={modeValues}";
            
            if (user.KidFriendly)
            {
                apiUrl += "&with_genres=16|10751";
            }
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

            // Add custom headers
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {apiToken}");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Unable to connect to API service. {response.StatusCode}");
            }



             string content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {

                return [];
            }
            else
            {
                try
                {
                    var movieResult = JsonConvert.DeserializeObject<MovieResult>(content);


                    if (movieResult?.results == null || movieResult.results.Count < 1)
                    {

                        return [];
                    }
                    else
                    {

                        return movieResult.results;
                    }

                }
                catch (Exception err)
                {
                    Debug.WriteLine($"Error: {err.Message}");
                    return [];
                }

            }



        }


    }
}
