using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMenuItemStorySample002
{
    public class MainViewModel : NotifyPropertyBase
    {
        public MainViewModel()
        {
            InitialMenuItems();
        }

        private ObservableCollection<MenuItemViewModel> _items;
        public ObservableCollection<MenuItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items , value);
        }


        private void InitialMenuItems()
        {
            Items = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Header = "File",
                    Items = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Header = "New",
                            Command = new RelayCommand((x) => { MessageBox.Show("New"); })
                        },
                        new MenuItemViewModel
                        {
                            Header = "Open",
                            Command = new RelayCommand((x) => { MessageBox.Show("Open"); })
                        },
                        new MenuItemViewModel
                        {
                            Header = "Save",
                            Command = new RelayCommand((x) => { MessageBox.Show("Save"); })
                        },
                        new MenuItemViewModel
                        {
                            Header = "Exit",
                            Command = new RelayCommand((x) => { MessageBox.Show("Exit"); })
                        }
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Edit",
                    Items = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Header = "Copy",
                            Command = new RelayCommand((x) => { MessageBox.Show("Copy"); })
                        },
                        new MenuItemViewModel
                        {
                            Header = "Cut",
                            Command = new RelayCommand((x) => { MessageBox.Show("Cut"); })
                        },
                        new MenuItemViewModel
                        {
                            Header = "Paste",
                            Command = new RelayCommand((x) => { MessageBox.Show("Paste"); })
                        }
                    }
                }
            };
        }
    }

    public class MenuItemViewModel : NotifyPropertyBase
    {
        private string _header;

        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        private RelayCommand _command;
        public RelayCommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        private ObservableCollection<MenuItemViewModel> _items;
        public ObservableCollection<MenuItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }       
    }
}
