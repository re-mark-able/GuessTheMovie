using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GuessTheMovie;

public partial class AnswerPage : ContentPage
{

    private User user;

    public AnswerPage()
	{
		InitializeComponent();
        user = DependencyService.Get<User>();

        Result lastResult = user.Results[user.CurrentNumber];

        statText.Text = $"Correctly answered {user.Correct} of {user.Answered} ({user.CurrentNumber - user.Answered + 1} skipped)";
        movieTitle.Text = lastResult.Answer;
        movieImage.Source = lastResult.Image;

        if ( lastResult.Correct == true)
        {
            resultText.TextColor = Colors.Green;
            resultText.Text = "CORRECT!";
        }
        else if (lastResult.Skipped == true)
        {
            resultText.TextColor = Colors.Red;
            resultText.Text = "Skipped";
        } else
        {
            resultText.TextColor = Colors.Red;
            resultText.Text = "Incorrect";
        }
        
        this.Title = user.Movies == true ? "Guess the Movie":  "Guess the Show";
        


    }


    private async void NextClick(object? sender, EventArgs e)
    {
        if (user.CurrentNumber >= 19)
        {
            var gameOverPage = new GameOverPage();
            await Navigation.PushAsync(gameOverPage);
        }
        else
        {         
                       
            var movieGuessPage = new MovieGuessPage();

            await Navigation.PushAsync(movieGuessPage);
        }

        

    }

}