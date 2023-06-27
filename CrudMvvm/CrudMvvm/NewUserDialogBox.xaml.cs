using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using DataAccessLibrary;
using Microsoft.VisualBasic.FileIO;

namespace CrudMvvm
{
    /// <summary>
    /// Interaction logic for NewUserDialogBox.xaml
    /// </summary>
    public partial class NewUserDialogBox : Window
    {
        public DialogViewModel viewModel = new();
        public static string usernameWatermark = "Username";
        public NewUserDialogBox()
        {
            InitializeComponent();
        }

        
    }
}
