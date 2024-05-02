using alcocalendar.Model;
using alcocalendar.View;
using alcocalendar.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace alcocalendar.ViewModel
{
    internal class JokeViewModel
    {
        private readonly JokeWindow _jokeWindow;

        public BindCommand CloseWin { get; set; }
        public JokeViewModel(JokeWindow jokeWindow)
        {
            _jokeWindow = jokeWindow;
            CloseWin = new BindCommand(_ => Closss());
        }
        public void Closss()
        {
            _jokeWindow.Close();
            Media media = new Media();
            media.Stop();
        }
    }
}
