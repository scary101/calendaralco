using alcocalendar.View;
using alcocalendar.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace alcocalendar.ViewModel
{
    public class MainWindowViewModel
    {
        public BindCommand Joke {  get; set; }
        private readonly INavigationService _navigationService;

        public MainWindowViewModel(Frame frame)
        {
            Joke = new BindCommand(_ => Prikol());
            _navigationService = new NavigationHelper(frame);
        }

        public void Prikol()
        {
            JokeWindow joke = new JokeWindow();
            joke.WindowState = WindowState.Maximized;
            joke.WindowStyle = WindowStyle.None;
            joke.Topmost = true;
            joke.Show();
        }

    }
}
