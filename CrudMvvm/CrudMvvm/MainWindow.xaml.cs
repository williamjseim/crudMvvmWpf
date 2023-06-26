using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DataAccessLibrary;

namespace CrudMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Binding dataContextBinding = new Binding();
        ModelView viewModel = new();
        public MainWindow()
        {
            InitializeComponent();
            dataContextBinding.Source = viewModel.List;
            dataContextBinding.Mode = BindingMode.TwoWay;
            dataContextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            viewModel.GetData();
            ShitGrid.DataContext = dataContextBinding;
            ShitGrid.ItemsSource = viewModel.List;
            viewModel.List.CollectionChanged += test;
        }

        void test(object sender, EventArgs e)
        {
            ShitGrid.ItemsSource = viewModel.List;
        }

        void OpenDialogBox(object sender, RoutedEventArgs e)
        {
            NewUserDialogBox dialog = new();
            dialog.ShowDialog();
            dialog.button.Click += viewModel.CreateNewUser;
        }

        private void EditData(object sender, RoutedEventArgs e)
        {
            try
            {
                shitModel data = (shitModel)((Button)e.Source).DataContext;
                viewModel.EditData(data);
            }
            catch (Exception a) { Debug.WriteLine(a+" fail"); }
        }

        private void DeleteData(object sender, RoutedEventArgs e)
        {
            try
            {
                shitModel data = (shitModel)((Button)e.Source).DataContext;
                viewModel.DeleteData(data);
            }
            catch (Exception a) { Debug.WriteLine(a + " fail"); }
        }
    }
}
