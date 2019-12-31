using ListviewCommand.Models;
using ListviewCommand.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListviewCommand.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string name;
        private int id;
        private string designation;
       

        private string branch;
      

        EmployeeDataList employeeDataList = new EmployeeDataList();
        ObservableCollection<Employee> employeeList = new ObservableCollection<Employee> { };
        public ObservableCollection<Employee> EmployeeList { get; set; }
        private string dispalyMessage;
        public ICommand AddEmployee { set; get; }
        public ICommand DeleteCommand { set; get; }
     
        public MainViewModel()
        {
            //employeeList= employeeDataList.GetEmoployeeList(); is wrong   ?? coz there the property is changing not variable value
            EmployeeList = employeeDataList.GetEmoployeeList();
            DeleteCommand = new Command<Employee>(Delete);
            AddEmployee = new Command(AddEmp);
        }




        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    RefreshData();

                    IsRefreshing = false;
                });
            }
        }

        private void RefreshData()
        {
            //Employee e = (Employee)item;
                  DispalyMessage = "e.EmployeeName";

        }

        private void AddEmp(object obj)
        {

              Application.Current.MainPage.Navigation.PushAsync (new EmployeeDetails());
           // Navigation.PushAsync(new EmployeeDetails());
        }

        private void Delete(Employee obj)
        {
            //employeeList.Remove(); is wrong   ?? coz there the property is changing not variable value
             EmployeeList.Remove(obj);
            //Navigation.PushModalAsync(new Page2());
        }

      
        public int EmployeeId {
            get => id;
            set
            {
                id = value;
            }
        }
        public string EmployeeName
        {
            get => name;
            set
            {
                name = value;
            }
        }
        public string Designation
        {
            get => designation;
            set
            {
                designation = value;
            }
        }
        public string Branch { get; set; }

        public ICommand ItemClickCommand
        {   
            get
            {
                return new Command((item) =>
                {
                    Employee e = (Employee)item;
                    DispalyMessage = e.EmployeeName;
                  OnPropertyChanged(nameof(DispalyMessage));
                    Application.Current.MainPage.Navigation.PushAsync(new EmployeeDetails());
                });
            }

        }

        public  string DispalyMessage
        {
            get
            {
                return "You clicked on"+ dispalyMessage;
            }
            set
            {
                dispalyMessage = value;
                //onpropertychange doest not work herer ???
             // OnPropertyChanged("DisplayMessage");
            }
        }

      

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
