using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public String Title { get; set; }
        public String Message { get; set; }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            if (AssociatedObject is Page)
            {
                (AssociatedObject as Page).RightTapped += RightClickMessageDialogBehavior_RightTapped;
            }
        }

        private async void RightClickMessageDialogBehavior_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        public void Detach()
        {
            if (AssociatedObject is Page)
            {
                (AssociatedObject as Page).RightTapped -= RightClickMessageDialogBehavior_RightTapped;
            }
        }
    }
}
