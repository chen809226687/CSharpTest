using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WPFTest.ViewModels
{
    public class TabControlVM : EntityBase
    {
        // 定义一个命令属性
        public ICommand ButtonClickCommand { get; }
        public TabControlVM()
        {
            var ssss = new BitmapImage(new Uri("pack://application:,,,/Resources/Add.ico"));
            if (_Items == null)
            {
                _Items = new ObservableCollection<TabItemModel>();

                _Items.Add(new TabItemModel()
                {
                    Header = "sasasasasasasqwq",
                    Description = "123456",
                    Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/Add.ico"))

                });
                for (int i = 0; i < 5; i++)
                {
                    _Items.Add(new TabItemModel()
                    {
                        Header = "TabTest" + i,
                        Description = "123456"
                    });
                }
                _Items.Add(new TabItemModel()
                {
                    Header = "TabTestqwqwqwqwqwq",
                    Description = "123456"
                });
            }
            ButtonClickCommand = new RelayCommand(OnButtonClick);

        }


        // 命令执行时触发的方法
        private void OnButtonClick()
        {
            if (Dock == Dock.Top)
            {
                Dock = Dock.Left;
            }
            else
            {
                Dock = Dock.Top;
            }
            Str = Dock.ToString();
        }


        private string _str = "szasasasas";
        public string Str
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
                RaisePropertyChanged(nameof(Str));
            }
        }


        private Dock _dock;
        public Dock Dock
        {
            get
            {
                return _dock;
            }
            set
            {
                _dock = value;
                RaisePropertyChanged(nameof(Dock));
            }
        }


        private ObservableCollection<TabItemModel> _Items = null;
        public ObservableCollection<TabItemModel> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }
    }


    public class TabItemModel : EntityBase
    {
        private object _icon;
        public object Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                RaisePropertyChanged("_icon");
            }
        }

        public string Header { get; set; }
        public string Description { get; set; }

    }



    public class EntityBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // 构造函数，接受执行和判断是否能执行的委托
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // 执行命令时调用的方法
        public void Execute(object parameter)
        {
            _execute();
        }

        // 判断命令是否可以执行的方法
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        // 当 CanExecute 结果变化时，更新 UI
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
