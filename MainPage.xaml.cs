using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GuessTheMovie
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            DependencyService.Register<User>();     
        }


        private async void StartGame(User user)
        {
            user.CurrentNumber = -1;
            user.Answered = 0;
            user.Correct = 0;
            user.StartTime = new DateTime();
          
                        
           MovieApiService service = new();
           user.MovieList = await service.GetMovie(user.Movies);

            var movieGuessPage = new MovieGuessPage();

            await Navigation.PushAsync(movieGuessPage);

        }


        private async void OnStartMovie(object? sender, EventArgs e)
        {
            
            User user = DependencyService.Get<User>();
            user.Movies = true;
            user.KidFriendly = kidFriendly.IsToggled;

            StartGame(user);
          
            
        }

        private async void OnStartTV(object? sender, EventArgs e)
        {

            User user = DependencyService.Get<User>();
            user.Movies = false;
            user.KidFriendly = kidFriendly.IsToggled;

            StartGame(user);

        }
    }
}
