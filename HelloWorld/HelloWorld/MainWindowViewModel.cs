using System;
using System.Windows.Input;

namespace HelloWorld
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            MyGreeting = "THE WORLD";
            MyCommand = new RelayCommand(() =>
            {
                MyGreeting = "hello";
            });
        }

        public string MyGreeting { get; set; }

        public ICommand MyCommand { get; set; }
    }

    public class RelayCommand : ICommand
    {

        public RelayCommand(Action whatShouldIDo)
        {
            Action = whatShouldIDo;
        }

        public Action Action { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action.Invoke();
        }
    }
}
