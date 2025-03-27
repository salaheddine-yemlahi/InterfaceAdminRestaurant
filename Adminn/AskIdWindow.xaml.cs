using System.Windows;

namespace Adminn
{
    public partial class AskIdWindow : Window
    {
        public string IdValue { get; private set; }

        public AskIdWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            IdValue = IdTextBox.Text;
            DialogResult = true;
        }

 
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
