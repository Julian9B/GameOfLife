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
    public partial class PatternPage : ContentPage
    {
        public PatternPage(string name, string type, string discoverer, string imageId)
        {
            InitializeComponent();

            Title = name;
            patternImage.Source = imageId;
            typeLabel.Text = $"Type: {type}";
            discovererLabel.Text = $"Discovered by: {discoverer}";
        }
    }
}