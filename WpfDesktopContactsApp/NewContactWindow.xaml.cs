using SQLite;
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
using WpfDesktopContactsApp.Classes;

namespace WpfDesktopContactsApp
{
    /// <summary>
    /// Lógica de interacción para NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save contact into the DB
            // First, create an object Contact, with the data we want to store in passed to its attributes
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextbox.Text
            };
            // Second, create path to the db <- UPDATE: These variables will be now created globally in App.xaml.cs, so that
            //                                          other windows can also access to the very same variable, without having
            //                                          to define it again.
            //string databaseName = "Contacts.db";
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string databasePath = System.IO.Path.Combine(folderPath, databaseName);
            // Third, create connection to the DB, create a table that accepts contacts and store the contact in the table
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            // Very important, CLOSE the connection to the DB at the end!!
            // connection.Close();
            // UPDATE: We dont need to close the connection manually anymore, because we take advantage of the fact that
            // the class SQLiteConnection implements the interface IDisposable (right click on the class and press "go to 
            // definition" to check that the class implements the interface). So that for, we use the keyword 'using'


            Close();
        }

    }
}
