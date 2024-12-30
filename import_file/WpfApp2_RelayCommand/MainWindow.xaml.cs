using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2_RelayCommand
{
    public partial class MainWindow : Window
    {
        // Declare ICommand properties for adding and removing and importing names
        public ICommand AddNameCommand { get; }
        public ICommand RemoveNameCommand { get; }
        public ICommand ImportNamesCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            UpdateNameCount();

            // Set the DataContext to this instance, so that the commands work
            this.DataContext = this;

            // Initialize commands with the appropriate functions.
            // The RelayCommand class is designed to take two parameters: 1. An Action<object> delegate for the execute method. 2. A Func<object, bool> delegate for the canExecute method(optional).
            AddNameCommand = new RelayCommand(_ => AddName(), _ => CanAddName());
            RemoveNameCommand = new RelayCommand(_ => RemoveName(), _ => CanRemoveName());
            ImportNamesCommand = new RelayCommand(_ => ImportNames());
        }

        // function to add name to the listbox if it is not empty and not already in the list
        private void AddName()
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
                UpdateNameCount();
            }

            if (lstNames.Items.Contains(txtName.Text))
            {
                MessageBox.Show("Name already exists");
                txtName.Clear();
            }
        }

        // function to check if the name is not empty --> can be added to the listbox
        private bool CanAddName()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text);
        }

        // function to remove name from the listbox if it is selected
        private void RemoveName()
        {
            if (lstNames.SelectedItem != null)
            {
                lstNames.Items.Remove(lstNames.SelectedItem);
                UpdateNameCount();
            }
        }

        // function to check if the name is selected --> can be removed from the listbox
        private bool CanRemoveName()
        {
            return lstNames.SelectedItem != null;
        }

        // function to update the count of names in the listbox
        private void UpdateNameCount()
        {
            txtCount.Text = $"Name Count: {lstNames.Items.Count}";
        }

        // function to import names from a file 
        private void ImportNames()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var fileContent = File.ReadAllText(openFileDialog.FileName);
                string[] names = fileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // If the entire content is treated as a single name, try splitting by commas
                if (names.Length == 1 && names[0].Contains(","))
                {
                    fileContent = fileContent.Replace(", ", ",");  // Remove spaces before commas
                    names = fileContent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                }

                foreach (var name in names)
                {
                    if (!lstNames.Items.Contains(name))
                    {
                        lstNames.Items.Add(name);
                    }
                }
                UpdateNameCount();
            }
        }
    }
}