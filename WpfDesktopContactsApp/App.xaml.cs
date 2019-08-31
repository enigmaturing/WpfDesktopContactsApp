using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDesktopContactsApp
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        // The variable databasePath is used in the two windows MainWindow and NewContactWindow, so 
        // I define it as a public static global in the App.xaml.cs, so that I can use it globally
        static string databaseName = "Contacts.db";  // this variable is only used in this class to conform the variable databasePath, so it is not marked as public
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // this variable is only used in this class to conform the variable databasePath, so it is not marked as public
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
