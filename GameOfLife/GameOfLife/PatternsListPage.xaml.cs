using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameOfLife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatternsListPage : ContentPage
    {
        public PatternsListPage()
        {
            InitializeComponent();

            PatternsList.ItemsSource = new List<string>
            {
                "Pond",
                "Beehive",
                "Block",
                "Glider",
                "Lightweight spaceship",
                "Spider",
                "Gosper glider gun"
            };
        }

        readonly List<Pattern> Patterns = new List<Pattern>()
        {
            new Pattern("Pond", "Still life", "JHC group", "https://conwaylife.com/w/images/1/10/Pond.png"),
            new Pattern("Glider", "Spaceship", " Richard K. Guy", "https://conwaylife.com/w/images/7/79/Glider.png"),
            new Pattern("Gosper glider gun", "Glider gun", " Bill Gosper", "https://conwaylife.com/w/images/9/9f/Gosperglidergun.png"),
            new Pattern("Lightweight spaceship", "Spaceship", "John Conway", "https://conwaylife.com/w/images/e/e2/Lwss.png"),
            new Pattern("Spider", "Spaceship", " David Bell", "https://conwaylife.com/w/images/8/84/Spider.png"),
            new Pattern("Block", "Still life", "John Conway", "https://conwaylife.com/w/images/4/48/Block.png"),
            new Pattern("Beehive", "Still life", "JHC group", "https://conwaylife.com/w/images/3/3c/Beehive.png")
        };

        private async void PatternsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            foreach (var pattern in Patterns)
            {
                if (pattern.Name == PatternsList.SelectedItem.ToString())
                {
                    await Navigation.PushAsync(new PatternPage(pattern.Name, pattern.Type, pattern.Discoverer, pattern.ImageId));
                }
            }
        }
    }
}