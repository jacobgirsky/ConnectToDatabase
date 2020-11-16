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
using System.Windows.Shapes;

namespace DatabaseExample
{
    /// <summary>
    /// Interaction logic for UpdatePerson.xaml
    /// </summary>
    public partial class UpdatePerson : Window
    {

        private Person person;

        public UpdatePerson(Person person)
        {
            InitializeComponent();
            this.person = person;
            firstNameTextbox.Text = person.FirstName;
            lastNameTextbox.Text = person.LastName;
            emailTextbox.Text = person.EmailAddress;
            phoneNumberTextbox.Text = person.PhoneNumber;
            id_text.Text = person.id.ToString();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            if (!id_text.Text.Equals("") && !firstNameTextbox.Text.Equals("") && !lastNameTextbox.Text.Equals("") &&
                !emailTextbox.Text.Equals("") && !phoneNumberTextbox.Text.Equals(""))
            {
                db.UpdatePerson(Convert.ToInt32(id_text.Text), firstNameTextbox.Text, lastNameTextbox.Text, emailTextbox.Text, phoneNumberTextbox.Text);

                MessageBox.Show("Record Updated.");
                this.Close();
                MainWindow mw = new MainWindow();
                mw.Show();
            }
            else
            {
                MessageBox.Show("Please enter all information.");
            }
            
        }
    }
}
