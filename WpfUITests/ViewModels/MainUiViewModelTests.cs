namespace WpfUITests.ViewModels
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WpfUI.ViewModels;

    [TestClass]
    public sealed class MainUiViewModelTests
    {
        [TestMethod]
        public void NewMainUiViewModel_CorrectSetup()
        {
            MainUiViewModel vm = new MainUiViewModel();

            Assert.IsFalse(vm.IsLoggedIn);
            Assert.IsNotNull(vm.Login);
            Assert.IsTrue(vm.Login.CanExecute(null));
            Assert.IsNotNull(vm.Logout);
            Assert.IsFalse(vm.Logout.CanExecute(null));
        }

        [TestMethod]
        public void MainUiViewModel_Login_LogsIn()
        {
            MainUiViewModel vm = new MainUiViewModel();

            vm.Login.Execute(null);

            Assert.IsTrue(vm.IsLoggedIn);
            Assert.IsFalse(vm.Login.CanExecute(null));
            Assert.IsTrue(vm.Logout.CanExecute(null));
        }

        [TestMethod]
        public void MainUiViewModel_Logout_LogsOut()
        {
            MainUiViewModel vm = new MainUiViewModel();

            vm.Login.Execute(null);
            vm.Logout.Execute(null);

            Assert.IsFalse(vm.IsLoggedIn);
            Assert.IsTrue(vm.Login.CanExecute(null));
            Assert.IsFalse(vm.Logout.CanExecute(null));
        }
    }
}
