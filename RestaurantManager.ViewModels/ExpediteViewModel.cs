using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        public ExpediteViewModel() : base()
        {
                
        }

        protected override void OnDataLoaded()
        {
            NotifyPropertyChanged("OrderItems");
        }

        public ObservableCollection<Order> OrderItems
        {
            get
            {
                return (base.Repository!=null)? base.Repository.Orders : null;
            }
        }
    }
}
