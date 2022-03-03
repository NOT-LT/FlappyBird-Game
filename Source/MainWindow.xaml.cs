using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace FlappyBird
{
    // Made By LT || @30_x

    public partial class MainWindow : Window
    {
        public static int Speed = 2, Score = 0, Gravity = 2;
        public static DispatcherTimer Timer, Timer2;
        public static bool GameOver = false, GameStarted = false;

        public MainWindow()
        {
            InitializeComponent();

            // Timer is for the pipes, bied movement
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(5);
            Timer.Tick += Timer_Tick;
            // Timer 2 is for counting the score
            Timer2 = new DispatcherTimer();
            Timer2.Interval = TimeSpan.FromMilliseconds(1000);
            Timer2.Tick += Timer2_Tick;

            StartGame();
            Thread.Sleep(25);
        }

        public void StartGame()
        {
            GameCanvas.Focus();
            Speed = 2; Score = 0; Gravity = 5;
            ScoreTxt.FontSize = 14; ScoreTxt.Content = $"Score: 0";

            // Organsising the pipes and bird locations before running the game
            foreach (var Photo in GameCanvas.Children.OfType<Image>())
            {
                if ((string)Photo.Tag == "pipe1")
                {
                    Canvas.SetLeft(Photo, 160);
                }
                if ((string)Photo.Tag == "pipe2")
                {
                    Canvas.SetLeft(Photo, 300);
                }
                if ((string)Photo.Tag == "pipe3")
                {
                    Canvas.SetLeft(Photo, 600);
                }
                if ((string)Photo.Tag == "TheBird")
                {
                    Canvas.SetLeft(Photo, 60); Canvas.SetTop(Photo, 117);
                }
            }
            GameStarted = false;
            ScoreTxt.FontSize = 11; ScoreTxt.Content = "Press R to start";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Define Rect VARIABLE for each the bird and the pipes, to check the *IntersectsWith*
            Rect TheBirdBox = new Rect()
            {
                Height = TheBird.Height,
                Width = TheBird.Width - 5,
                Location = new Point(Canvas.GetLeft(TheBird) - 5, Canvas.GetTop(TheBird) - 8),
                Size = new Size(TheBird.Width - 5, TheBird.Height)
            };
            Rect TopPipe1Box = new Rect() { Height = TopPipe1.Height, Width = TopPipe1.Width, Location = new Point(Canvas.GetLeft(TopPipe1) - 5, Canvas.GetTop(TopPipe1) - 8), Size = new Size(TopPipe1.Width, TopPipe1.Height) };
            Rect DownPipe1Box = new Rect() { Height = DownPipe1.Height, Width = DownPipe1.Width, Location = new Point(Canvas.GetLeft(DownPipe1) - 5, Canvas.GetTop(DownPipe1) - 8), Size = new Size(DownPipe1.Width, DownPipe1.Height) };
            Rect TopPipe2Box = new Rect() { Height = TopPipe2.Height, Width = TopPipe2.Width             ,   Location = new Point(Canvas.GetLeft(TopPipe2) - 5, Canvas.GetTop(TopPipe2) - 8), Size = new Size(TopPipe2.Width, TopPipe2.Height) };
            Rect DownPipe2Box = new Rect(){Height = DownPipe2.Height, Width = DownPipe2.Width, Location = new Point(Canvas.GetLeft(DownPipe2) - 5, Canvas.GetTop(DownPipe2) - 8),Size = new Size(DownPipe2.Width, DownPipe2.Height)};
            Rect TopPipe3Box = new Rect(){ Height = TopPipe3.Height, Width = TopPipe3.Width, Location = new Point(Canvas.GetLeft(TopPipe3) - 5, Canvas.GetTop(TopPipe3) - 8), Size = new Size(TopPipe3.Width, TopPipe3.Height)};
            Rect DownPipe3Box = new Rect(){Height = DownPipe3.Height,Width = DownPipe3.Width,Location = new Point(Canvas.GetLeft(DownPipe3) - 5, Canvas.GetTop(DownPipe3) - 8),Size = new Size(DownPipe3.Width, DownPipe3.Height)};


            // Check if the bird hits any pipe
            if (TheBirdBox.IntersectsWith(TopPipe1Box) || TheBirdBox.IntersectsWith(DownPipe1Box) ||
                TheBirdBox.IntersectsWith(TopPipe2Box) || TheBirdBox.IntersectsWith(DownPipe2Box) ||
                TheBirdBox.IntersectsWith(TopPipe3Box) || TheBirdBox.IntersectsWith(DownPipe3Box))
            {
                EndGame();
            }
            


            // Check if the FlappyBird Is flying above the pipes or hit the floor.
            if (Canvas.GetTop(TheBird) >= 248 || Canvas.GetTop(TheBird) <= -29)
            {
                EndGame();
            }

            // Set the x point of each pipe
            foreach (var Photo in GameCanvas.Children.OfType<Image>())
            {
                if ((string)Photo.Tag == "pipe1")
                {
                    // Moving the pipe
                    Canvas.SetLeft(Photo, Canvas.GetLeft(Photo) - Speed);
                    if ((int)Canvas.GetLeft(Photo) <= -50)
                    {
                        // Rest the pipe's location after disappearing from the screen
                        Canvas.SetLeft(Photo, 750);
                    }
                }
                if ((string)Photo.Tag == "pipe2")
                {
                    Canvas.SetLeft(Photo, Canvas.GetLeft(Photo) - Speed);
                    if ((int)Canvas.GetLeft(Photo) <= -50)
                    {
                        Canvas.SetLeft(Photo, 750);
                    }
                }
                if ((string)Photo.Tag == "pipe3")
                {
                    Canvas.SetLeft(Photo, Canvas.GetLeft(Photo) - Speed);
                    if ((int)Canvas.GetLeft(Photo) <= -50)
                    {
                        Canvas.SetLeft(Photo, 750);
                    }
                }
            }

            // Set the bird y position [UP AND DOWN]
            Canvas.SetTop(TheBird, Canvas.GetTop(TheBird) + Gravity);
        }

    
        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Increasing the score, +1 each second
            Score++; ScoreTxt.Content = $"Score: {Score}";

            // Increasing the speed
            if (Score >= 2000)
            {
                Speed = 8;
            }
            else if (Score >= 1000)
            {
                Speed = 7;
            }
            else if (Score >= 500)
            {
                Speed = 6;
            }
            else if (Score >= 100)
            {
                Speed = 5;
            }
            else if (Score >= 100)
            {
                Speed = 4;
            }
            else if (Score >= 25)
            {
                Speed = 4;
            }
            else
            {
                Speed = 3;
            }
        }

        public void EndGame()
        {
            Timer.Stop(); Timer2.Stop();
            GameStarted = false;
            MessageBox.Show($"GameOver, Your score was {Score}", "Flappy Bird Game", MessageBoxButton.OK, MessageBoxImage.Information,MessageBoxResult.OK,MessageBoxOptions.DefaultDesktopOnly);
            Score = 0;
            StartGame();
        }

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            // if Space is pressed The gravity will be (-) so the bird will fly
            if (e.Key == Key.Space && GameStarted == true)
            {
                Gravity = -4;
            }

            // if R is pressed the game wil start
            if (e.Key == Key.R && GameStarted == false)
            {
                GameStarted = true;
                ScoreTxt.FontSize = 14; ScoreTxt.Content = $"Score: 0";
                Timer.Start();
                Timer2.Start();
            }
        }

        private void GameCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            // if Space is not pressed The gravity will be (+) so the bird will gp down
            if (e.Key == Key.Space)
            {
                Gravity = 4;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try { Application.Current.Shutdown(); } catch (Exception) { Environment.Exit(0); }
        }

    }
}