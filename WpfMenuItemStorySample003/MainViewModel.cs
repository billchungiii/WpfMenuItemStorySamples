using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfMenuItemStorySample003
{
    public class MainViewModel : NotifyPropertyBase
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;
        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        private ICommand _menuOpeningCommand;
        public ICommand MenuOpeningCommand
        {
            get
            {
                if (_menuOpeningCommand == null)
                {
                    _menuOpeningCommand = new RelayCommand((x) =>
                    {
                        foreach (var item in MenuItems)
                        {
                            if (BorderDictionary["lightSteelBlueBorder"].IsMouseOver)
                            {
                                if (item.Header == "File")
                                {
                                    item.IsEnabled = true; 
                                }
                                else
                                {
                                    item.IsEnabled = false;
                                }
                            }
                            else if (BorderDictionary["springGreenBorder"].IsMouseOver)
                            {
                                if (item.Header == "Edit")
                                {
                                    item.IsEnabled = true;
                                }
                                else
                                {
                                    item.IsEnabled = false;
                                }
                            }
                        }
                    });
                }
                return _menuOpeningCommand;
            }
        }

        private ICommand _menuClosingCommand;
        public ICommand MenuClosingCommand
        {
            get
            {
                if (_menuClosingCommand == null)
                {
                    _menuClosingCommand = new RelayCommand((x) =>
                    {
                        Debug.WriteLine("MenuClosingCommand");
                    });
                }
                return _menuClosingCommand;
            }
        }

        private ICommand _borderLoadedCommand;

        public ICommand BorderLoadedCommand
        {
            get
            {
                if (_borderLoadedCommand == null)
                {
                    _borderLoadedCommand = new RelayCommand((x) =>
                    {
                        var border = x as Border;
                        if (border != null)
                        {
                            if (!BorderDictionary.ContainsKey(border.Name))
                            {
                                BorderDictionary.Add(border.Name, border);
                            }
                        }
                    });
                }
                return _borderLoadedCommand;
            }
        }

        private Dictionary<string, Border> BorderDictionary { get; set; }

        private void InitialMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Header = "File",
                    IsEnabled = false,
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Header = "New",
                            Command = new RelayCommand((x) => { Console.WriteLine("New"); }),
                            IsEnabled = true
                        },
                        new MenuItemViewModel
                        {
                            Header = "Open",
                            Command = new RelayCommand((x) => { Console.WriteLine("Open"); }),
                            IsEnabled = true
                        },
                        new MenuItemViewModel
                        {
                            Header = "Save",
                            Command = new RelayCommand((x) => { Console.WriteLine("Save"); }),
                            IsEnabled = true
                        },
                        new MenuItemViewModel
                        {
                            Header = "Exit",
                            Command = new RelayCommand((x) => { Console.WriteLine("Exit"); }),
                            IsEnabled = true
                        }
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Edit",
                    IsEnabled = false,
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Header = "Copy",
                            Command = new RelayCommand((x) => { Console.WriteLine("Copy"); }),
                            IsEnabled = true
                        },
                        new MenuItemViewModel
                        {
                            Header = "Paste",
                            Command = new RelayCommand((x) => { Console.WriteLine("Paste"); }),
                            IsEnabled = true
                        }
                    }
                }
            };
        }

        public MainViewModel()
        {
            BorderDictionary = new Dictionary<string, Border>();
            InitialMenuItems();
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

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private RelayCommand _command;
        public RelayCommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        private ObservableCollection<MenuItemViewModel> _menuItems;
        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }
    }
}
