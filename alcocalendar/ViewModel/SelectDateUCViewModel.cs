using alcocalendar.Model;
using alcocalendar.View;
using alcocalendar.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace alcocalendar.ViewModel
{
    public class SelectDateUCViewModel : BindHelper
    {
        private readonly INavigationService _navigationService;
        private int _dayNumber;

        public BindCommand OpenAlcoMenu { get; private set; }
        public BindCommand ClearDay { get; private set; }

        public int DayNumber
        {
            get { return _dayNumber; }
            set
            {
                _dayNumber = value;
                OnPropertyChanged();
            }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public SelectDateUCViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            OpenAlcoMenu = new BindCommand(_ => Open());
            ClearDay = new BindCommand(_ => Clear());
        }

        public void Open()
        {
            _navigationService.NavigateTo("SelectAlcoPageView", Date, _navigationService);
        }
        public void Clear()
        {
            var days = SerDeser.DeserData<SelectDay>("zametki.json");
            var day = days.FirstOrDefault(i => i.date == Date);
            if (day != null)
            {
                days.Remove(day);
                Image = null;
                SerDeser.SerData<SelectDay>(days, "zametki.json");
            }
        }
    }



}
