namespace WpfUITests.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Windows;
    using System.Windows.Data;
    using WpfUI.Converters;

    [TestClass]
    public sealed class BooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void NewBooleanToVisibilityConverter_CorrectSetup()
        {
            BooleanToVisibilityConverter conv = new BooleanToVisibilityConverter();

            Assert.IsFalse(conv.IsInverse);
        }

        [TestMethod]
        public void BooleanToVisibilityConverter_ConvertTrue_Visible()
        {
            IValueConverter conv = new BooleanToVisibilityConverter();
            object converted = conv.Convert(true, typeof(Visibility), null, null);

            Assert.IsInstanceOfType(converted, typeof(Visibility));
            Assert.AreEqual(Visibility.Visible, converted);
        }

        [TestMethod]
        public void BooleanToVisibilityConverter_ConvertFalse_Collapsed()
        {
            IValueConverter conv = new BooleanToVisibilityConverter();
            object converted = conv.Convert(false, typeof(Visibility), null, null);

            Assert.IsInstanceOfType(converted, typeof(Visibility));
            Assert.AreEqual(Visibility.Collapsed, converted);
        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverter_ConvertTrue_Collapsed()
        {
            IValueConverter conv = new BooleanToVisibilityConverter() { IsInverse = true };
            object converted = conv.Convert(true, typeof(Visibility), null, null);

            Assert.IsInstanceOfType(converted, typeof(Visibility));
            Assert.AreEqual(Visibility.Collapsed, converted);
        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverter_ConvertFalse_Visible()
        {
            IValueConverter conv = new BooleanToVisibilityConverter() { IsInverse = true };
            object converted = conv.Convert(false, typeof(Visibility), null, null);

            Assert.IsInstanceOfType(converted, typeof(Visibility));
            Assert.AreEqual(Visibility.Visible, converted);
        }

        [TestMethod]
        public void BooleanToVisibilityConverter_ConvertBackVisible_True()
        {
            IValueConverter conv = new BooleanToVisibilityConverter();
            object converted = conv.ConvertBack(Visibility.Visible, typeof(bool), null, null);

            Assert.IsInstanceOfType(converted, typeof(bool));
            Assert.AreEqual(true, converted);
        }

        [TestMethod]
        public void BooleanToVisibilityConverter_ConvertBackCollapsed_False()
        {
            IValueConverter conv = new BooleanToVisibilityConverter();
            object converted = conv.ConvertBack(Visibility.Collapsed, typeof(bool), null, null);

            Assert.IsInstanceOfType(converted, typeof(bool));
            Assert.AreEqual(false, converted);
        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverter_ConvertBackCollapsed_True()
        {
            IValueConverter conv = new BooleanToVisibilityConverter() { IsInverse = true };
            object converted = conv.ConvertBack(Visibility.Collapsed, typeof(bool), null, null);

            Assert.IsInstanceOfType(converted, typeof(bool));
            Assert.AreEqual(true, converted);
        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverter_ConvertBackVisible_False()
        {
            IValueConverter conv = new BooleanToVisibilityConverter() { IsInverse = true };
            object converted = conv.ConvertBack(Visibility.Visible, typeof(bool), null, null);

            Assert.IsInstanceOfType(converted, typeof(bool));
            Assert.AreEqual(false, converted);
        }
    }
}
