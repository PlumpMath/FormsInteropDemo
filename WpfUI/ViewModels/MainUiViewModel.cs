namespace WpfUI.ViewModels
{
    using System.Windows.Input;

    sealed class MainUiViewModel : ViewModelBase
    {
        private readonly RelayCommand _login, _logout;
        private bool _isLoggedIn;

        public MainUiViewModel()
        {
            _login = new RelayCommand(this.ExecuteLogin, this.CanExecuteLogin);
            _logout = new RelayCommand(this.ExecuteLogout, this.CanExecuteLogout);
            _isLoggedIn = false;
        }

        public ICommand Login { get { return _login; } }

        public ICommand Logout { get { return _logout; } }

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            private set
            {
                if (this.SetProperty(ref _isLoggedIn, value))
                {
                    _login.EmitCanExecuteChanged();
                    _logout.EmitCanExecuteChanged();
                }
            }
        }

        private void ExecuteLogin(object parameter)
        {
            this.IsLoggedIn = true;
        }

        private bool CanExecuteLogin(object parameter)
        {
            return !_isLoggedIn;
        }

        private void ExecuteLogout(object parameter)
        {
            this.IsLoggedIn = false;
        }

        private bool CanExecuteLogout(object parameter)
        {
            return _isLoggedIn;
        }
    }
}
