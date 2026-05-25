using System.Diagnostics;

namespace GuessTheMovie;

public partial class GameOverPage : ContentPage
{
	public GameOverPage()
	{
		InitializeComponent();

        User user = DependencyService.Get<User>();
       
        TimeSpan duration = DateTime.Now - user.StartTime;


        float rate = user.Correct > 0 ? user.Correct / user.Answered * 100 : 0;

       
        endTime.Text = $"Ended after {duration.Minutes}m {duration.Seconds}s. {user.Correct} of {user.Answered} ({rate}%) correct.";

        collectionView.ItemsSource = user.Results;
        collectionView.ItemTemplate = new DataTemplate(() =>
        {


            Grid grid = new Grid { Padding = 10 };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Image image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 50, WidthRequest=25 };
            image.SetBinding(Image.SourceProperty, "Image");

            Label nameLabel = new Label { FontAttributes = FontAttributes.Bold };
            nameLabel.SetBinding(Label.TextProperty, "Answer");

            Label locationLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
            locationLabel.SetBinding(Label.TextProperty, "Guess");
            Label resultLabel = new Label { VerticalOptions = LayoutOptions.End };
            
            resultLabel.SetBinding(Label.TextProperty, "ResultText");
            resultLabel.SetBinding(Label.TextColorProperty, "ResultTextColor");

            Grid.SetRowSpan(image, 3);

            grid.Add(image);
            grid.Add(nameLabel, 1, 0);
            grid.Add(locationLabel, 1, 1);
            grid.Add(resultLabel, 1, 2);

            return grid;
        });
        


    }


    private async void PlayAgainClick(object? sender, EventArgs e)
    {

        DependencyService.RegisterSingleton<User>(new());
        await Navigation.PopToRootAsync();

    }


}