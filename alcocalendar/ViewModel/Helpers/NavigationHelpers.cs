using alcocalendar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace alcocalendar.ViewModel.Helpers
{
    public interface INavigationService
    {
        void NavigateTo(string pageKey, DateTime date, INavigationService navigationService);
        void GoToMain();
    }

    public class NavigationHelper : INavigationService
    {
        private readonly Frame _frame;

        public NavigationHelper(Frame frame)
        {
            _frame = frame ?? throw new ArgumentNullException(nameof(frame));
        }

        public void NavigateTo(string pageKey, DateTime date, INavigationService navigationService)
        {
            switch (pageKey)
            {
                case "SelectAlcoPageView":
                    _frame.Navigate(new SelectAlcoPageView(date, navigationService));
                    break;
                default:
                    break;
            }
        }
        public void GoToMain()
        {
            _frame.Navigate(new SelectDatePage(_frame));
        }
    }


}
