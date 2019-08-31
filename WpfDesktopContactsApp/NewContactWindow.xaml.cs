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
            // Second, create path to the db
            string databaseName = "Contacts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = System.IO.Path.Combine(folderPath, databaseName);
            // Third, create connection to the DB, create a table that accepts contacts and store the contact in the table
            SQLiteConnection connection = new SQLiteConnection(databasePath);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
            // Very important, CLOSE the connection to the DB at the end!!
            connection.Close();

            Close();
        }

    }
}
