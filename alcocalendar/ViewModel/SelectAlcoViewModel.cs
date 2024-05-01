using alcocalendar.Model;
using alcocalendar.View;
using alcocalendar.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace alcocalendar.ViewModel
{
    public class SelectAlcoViewModel : BindHelper
    {
        public ObservableCollection<SelectAlcoUCViewModel> userconrol { get; set; }
        private List<SelectAlcoModel> alcos {  get; set; }
        public BindCommand Save {  get; private set; }
        public BindCommand Exit { get; private set; }
        public DateTime date { get; set; }
        private INavigationService _navigationService { get; set; }
        private List<SelectDay> days = SerDeser.DeserData<SelectDay>("zametki.json");

        public SelectAlcoViewModel(DateTime date, INavigationService navigationService)
        {
            _navigationService = navigationService;
            this.date = date.Date;
            Save = new BindCommand(_ => SaveCard());
            Exit = new BindCommand(_ => GoBack());
            alcos = new List<SelectAlcoModel>
            {
                new SelectAlcoModel {alco = (int)Alco.Beer, path = "/Images/beer.png" },
                new SelectAlcoModel {alco = (int)Alco.Martini, path = "/Images/martini.png" },
                new SelectAlcoModel {alco = (int)Alco.Vodka, path = "/Images/vodka.png" },
                new SelectAlcoModel {alco = (int)Alco.Champagne, path = "/Images/champagne.png" },
                new SelectAlcoModel {alco = (int)Alco.Whiskey, path = "/Images/whiskey.png" }
            };

            userconrol = new ObservableCollection<SelectAlcoUCViewModel>();

            var day = days.FirstOrDefault(i => i.date.Date == date);

            for (int i = 0; i < alcos.Count(); i++)
            {
                SelectAlcoUCViewModel card = new SelectAlcoUCViewModel();
                card.ImagePath = alcos[i].path;
                try
                {
                    if (day.alcolist.Any(item => item.alco == alcos[i].alco))
                    {
                        card.Selected = true;
                    }
                }
                catch (Exception ex)
                {

                }
                userconrol.Add(card);
            }

        }

        public void SaveCard()
        {
            List<SelectAlcoModel> alco = new List<SelectAlcoModel>();
            var yad = days.FirstOrDefault(i => i.date.Date == date);
            for (int i = 0; i < userconrol.Count(); i++)
            {
                if (userconrol[i].Selected == true)
                {
                    alcos[i].isChosee = true;
                    alco.Add(alcos[i]);
                    
                }
                
            }
            if(alco != null)
            {
                if(alco != null)
                {
                    SelectDay day = new SelectDay(date);
                    day.alcolist = alco;
                    if (yad != null)
                    {
                        int index = days.IndexOf(yad);
                        days[index] = day;
                    }
                    else
                    {
                        days.Add(day);
                    }
                    
                    SerDeser.SerData<SelectDay>(days, "zametki.json");
                    _navigationService.GoToMain();
                }
                
            }
        }
        public void GoBack()
        {
            _navigationService.GoToMain();
        }
    }

}
