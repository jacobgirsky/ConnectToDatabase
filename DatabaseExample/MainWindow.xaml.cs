using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseExample
{

    public partial class MainWindow : Window
    {
        private readonly DataAccess db;

        public MainWindow()
        {
            InitializeComponent();
            db = new DataAccess();
        }

        public void UpdateListBox()
        {
            peopleFoundListbox.ItemsSource = db.GetPeople(lastNameText.Text);
            peopleFoundListbox.DisplayMemberPath = "FullInfo";
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!lastNameText.Text.Equals(""))
            {
                NoResultsFound();
                UpdateListBox();
            }
        }

        public void NoResultsFound()
        {
            if (db.GetPeople(lastNameText.Text).Count == 0)
            {
                MessageBox.Show("No results found.");
            }
        }

        private void addRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!lastNameTextBox.Text.Equals("") && !firstNameText.Text.Equals("") && !emailText.Text.Equals("") &&
            !phoneNumberText.Text.Equals(""))
            {
                db.InsertPerson(lastNameTextBox.Text, firstNameText.Text, emailText.Text, phoneNumberText.Text);
                lastNameTextBox.Text = "";
                firstNameText.Text = "";
                emailText.Text = "";
                phoneNumberText.Text = "";
            }
            else
            {
                MessageBox.Show("Enter all information.");
            }
        }

        private void peopleFoundListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var person = (Person)item.SelectedItem;
            MessageBoxResult answer = MessageBox.Show("Do you want to edit this record?", "Edit Record", MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes)
            {
                UpdatePerson upd = new UpdatePerson(person);
                Hide();
                upd.Show();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            lastNameText.Text = "";
            peopleFoundListbox.ItemsSource = "";
        }
    }
}
