using alcocalendar.Model;
using alcocalendar.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace alcocalendar.View
{

    public partial class JokeWindow : Window
    {
        

        public JokeWindow()
        {
            InitializeComponent();
            Media media = new Media();
            media.Play();
            DataContext = new JokeViewModel(this);
        }

    }

}
