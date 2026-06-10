using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GuessTheMovie
{
    public partial class MainPage : ContentPage
    {
        bool KidFriendly = Preferences.Default.Get("kid_friendly", false);

        public MainPage()
        {
            InitializeComponent();
            DependencyService.Register<User>();
            kidFriendly.IsToggled = KidFriendly;
        }

        private void OnPageSizeChange(object sender, EventArgs e)
        {
            if (Width > Height)
            {
                ButtonStack.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                ButtonStack.Orientation = StackOrientation.Vertical;
            }
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
            Preferences.Default.Set("kid_friendly", kidFriendly.IsToggled);
            StartGame(user);
          
            
        }

        private async void OnStartTV(object? sender, EventArgs e)
        {

            User user = DependencyService.Get<User>();
            user.Movies = false;
            user.KidFriendly = kidFriendly.IsToggled;
            Preferences.Default.Set("kid_friendly", kidFriendly.IsToggled);
            StartGame(user);

        }
    }
}
