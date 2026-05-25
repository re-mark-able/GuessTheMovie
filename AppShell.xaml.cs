namespace GuessTheMovie
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Guess The Movie", typeof(MovieGuessPage));
        }
    }
}
