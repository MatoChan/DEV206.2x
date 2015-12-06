using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
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
                    this.OnPropertyChanged();
                }
            }
        }

        private List<MenuItem> _CurrentlySelectedMenuItems = new List<MenuItem>();
        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._CurrentlySelectedMenuItems; }
            set
            {
                if (value != this._CurrentlySelectedMenuItems)
                {
                    this._CurrentlySelectedMenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
