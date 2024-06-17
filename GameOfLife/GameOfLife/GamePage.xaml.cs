using System;
using Xamarin.Forms;

namespace GameOfLife
{
    public partial class GamePage : ContentPage
    {
        private int mapSize = 40; // Początkowy rozmiar mapy
        private int stepSpeed = 20; // Początkowa prędkość kroku

        private bool[,] cells;
        private bool isRunning = false;
        private bool[,] nextGeneration;

        // kod główny
        public GamePage()
        {
            InitializeComponent();
            InitializeMap();
        }

        // renderowanie planszy
        private void InitializeMap()
        {
            cells = new bool[mapSize, mapSize];
            nextGeneration = new bool[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    cells[i, j] = false;
                    var box = new BoxView { BackgroundColor = Color.Black };
                    map.Children.Add(box, j, i);
                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) =>
                    {
                        cells[Grid.GetRow(box), Grid.GetColumn(box)] = !cells[Grid.GetRow(box), Grid.GetColumn(box)];
                        box.BackgroundColor = cells[Grid.GetRow(box), Grid.GetColumn(box)] ? Color.White : Color.Black;
                    };
                    box.GestureRecognizers.Add(tapGestureRecognizer);
                }
            }
        }

        // uruchomienie symulacji
        private async void Start_Clicked(object sender, EventArgs e)
        {
            isRunning = true;
            while (isRunning)
            {
                await System.Threading.Tasks.Task.Delay(stepSpeed);
                CalculateNextGeneration();
                UpdateMap();
            }
        }

        // zatrzymanie symulacji
        private void Stop_Clicked(object sender, EventArgs e)
        {
            isRunning = false;
        }

        // wyczyszczenie planszy
        private void Clear_Clicked(object sender, EventArgs e)
        {
            isRunning = false;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    cells[i, j] = false;
                }
            }
            UpdateMap();
        }

        // zmiana prędkości symulacji
        private void SpeedSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            stepSpeed = (int)e.NewValue;
            speedLabel.Text = stepSpeed.ToString();
        }

        // modyfikowanie stanu komórek w tablicy
        private void CalculateNextGeneration()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    int neighbors = CountNeighbors(i, j);
                    if (cells[i, j])
                    {
                        nextGeneration[i, j] = neighbors == 2 || neighbors == 3;
                    }
                    else
                    {
                        nextGeneration[i, j] = neighbors == 3;
                    }
                }
            }

            Array.Copy(nextGeneration, cells, nextGeneration.Length);
        }

        // liczenie żywych sąsiadów dla komórki
        private int CountNeighbors(int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (i == 0 && j == 0)
                        continue;

                    if (newX >= 0 && newX < mapSize && newY >= 0 && newY < mapSize)
                    {
                        if (cells[newX, newY])
                            count++;
                    }
                }
            }
            return count;
        }

        // modyfikowanie planszy na podstawie stanu komórek z tablicy
        private void UpdateMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var box = (BoxView)map.Children[(i * mapSize) + j];
                    box.BackgroundColor = cells[i, j] ? Color.White : Color.Black;
                }
            }
        }
    }
}
