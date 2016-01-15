using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Models;
using System.Windows.Input;
using System;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            AddToOrderCommand = new DelegateCommand<MenuItem>(AddToOrderExecute);
            SubmitOrderCommand = new DelegateCommand<string>(SubmitOrderExecute);
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        private List<MenuItem> _MenuItems = new List<MenuItem>();
        public List<MenuItem> MenuItems
        { 
            get { return this._MenuItems; }
            set
            {
                if (value != this._MenuItems)
                {
                    this._MenuItems = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> _CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._CurrentlySelectedMenuItems; }
            set
            {
                if (value != this._CurrentlySelectedMenuItems)
                {
                    this._CurrentlySelectedMenuItems = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand<MenuItem> AddToOrderCommand { get; set; }
        private void AddToOrderExecute(MenuItem menuItem)
        {
            this.CurrentlySelectedMenuItems.Add(menuItem);
        }

        public DelegateCommand<string> SubmitOrderCommand { get; set; }
        private void SubmitOrderExecute(string specialRequest)
        {
            var order = new Order { Complete = false, Expedite = false, SpecialRequests = specialRequest, Table = base.Repository.Tables.Last(), Items = new List<MenuItem>(CurrentlySelectedMenuItems) };            
            base.Repository.Orders.Add(order);
            CurrentlySelectedMenuItems.Clear();
        }
        
    }
}
