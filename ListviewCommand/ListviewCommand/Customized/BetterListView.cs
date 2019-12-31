using ListviewCommand.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListviewCommand.NewFolder
{

    public class BetterListView :Behavior<ListView>
       
    {
       
        public static BindableProperty ItemClickedCommandProperty =
            BindableProperty.Create(
                                    nameof(ItemClickedCommand),
                                    typeof(ICommand),
                                    typeof(BetterListView),
                                    null);
        public ICommand ItemClickedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ItemClickedCommandProperty);
            }
            set
            {
                this.SetValue(ItemClickedCommandProperty,value);
            }
        }

        public BetterListView()
        {
            this.ItemTapped += OnItemTapped;

        }


        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item!= null)
            {
                ItemClickedCommand?.Execute(e.Item);
                SelectedItem = null;
                
            }
           
        }
    }
}
