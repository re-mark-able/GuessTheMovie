
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace GuessTheMovie;

public partial class MovieGuessPage : ContentPage
{

    public MovieItem currentItem;
    public User user;

    public MovieGuessPage()
	{
		InitializeComponent();
        user = DependencyService.Get<User>();

        user.CurrentNumber = user.CurrentNumber + 1;

        roundNum.Text = $"Round {user.CurrentNumber + 1} of 20";

        if (user.Movies)
        {
            this.Title = "Guess the Movie";
            currentItem = new MovieItem
            {
                Title = user.MovieList[user.CurrentNumber].title,
                MaskedTitle = Regex.Replace(user.MovieList[user.CurrentNumber].title, "[A-Za-z]", "•"),
                Plot = $"[{user.MovieList[user.CurrentNumber].release_date?.Substring(0, 4)}] {Regex.Replace(user.MovieList[user.CurrentNumber].overview, user.MovieList[user.CurrentNumber].title, "???")}",
                Image = $"https://image.tmdb.org/t/p/original{user.MovieList[user.CurrentNumber].poster_path}"
            };
        }
        else
        {
            this.Title = "Guess the Show";
            currentItem = new MovieItem

            {
                Title = user.MovieList[user.CurrentNumber].name,
                MaskedTitle = user.MovieList[user.CurrentNumber].name == null ? null : Regex.Replace(user.MovieList[user.CurrentNumber].name, "[A-Za-z0-9]", "•"),
                Plot = $"[{user.MovieList[user.CurrentNumber].first_air_date?.Substring(0, 4)}] {Regex.Replace(user.MovieList[user.CurrentNumber].overview, user.MovieList[user.CurrentNumber].name, "???")}",
                Image = $"https://image.tmdb.org/t/p/original{user.MovieList[user.CurrentNumber].poster_path}",
                
            };
        }

        movieTitle.Text = currentItem.MaskedTitle;
        moviePlot.Text = currentItem.Plot;
    }

    public async void OnSkipClicked(object? sender, EventArgs e)
    {
        Result result = new Result
        {
            Id = user.CurrentNumber,
            Answer = currentItem.Title,
            Guess = "",
            Skipped = true,
            ResultText = "Skipped",
            ResultTextColor = "DarkGray",
            Image = currentItem.Image
        };
        user.Results.Add(result);

        var answerPage = new AnswerPage();

        await Navigation.PushAsync(answerPage);
    }


    public async void OnSubmitClicked(object? sender, EventArgs e)
    {


        if (guessInput.Text == "" || guessInput.Text == null)
        {
            return;
        }

        bool answerIsCorrect = currentItem.Title != null && Regex.Replace(currentItem.Title.ToLower(), "[^A-Za-z0-9]", "") == Regex.Replace(guessInput.Text.ToLower(), "[^A-Za-z0-9]", "") ? true : false;

        user.Answered = user.Answered + 1;
        user.Correct = answerIsCorrect == true ? user.Correct + 1 : user.Correct;

        Result result = new Result
        {
            Id = user.CurrentNumber,
            Answer = currentItem.Title,
            Guess = guessInput.Text,
            Skipped = false,
            Correct = answerIsCorrect,
            ResultText = !answerIsCorrect ? "Incorrect" : "Correct",
            ResultTextColor = !answerIsCorrect ? "DarkRed" : "Green",
            Image = currentItem.Image
        };
        user.Results.Add(result);

        var answerPage = new AnswerPage();

        await Navigation.PushAsync(answerPage);

    }

}