using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace CrudMvvm
{
    public class ModelView : ObservableObject
    {
        SqlDataAccess sql = new();
        TempDataGetter TempDataGetter;

        private static ObservableCollection<shitModel> list = new();
        public ObservableCollection<shitModel> List { get { return list; } set { list = value; OnPropertyChanged(); } }

        public ModelView()
        {
            TempDataGetter = new(sql);
        }

        public async Task GetData()
        {
            List.Clear();
            foreach (var item in await TempDataGetter.GetData())
            {
                list.Add(item);
            }
        }

        public async void EditData(shitModel data)
        {
            NewUserDialogBox editUserBox = new();
            editUserBox.DataContext = new DialogViewModel { Password = data.passWord, Username = data.userName, id = data.id };
            editUserBox.button.Click += SubmitEditedData;
            editUserBox.ShowDialog();
            //await TempDataGetter.EditData(data);
            Debug.Print(data.ToString());
        }

        public async void SubmitEditedData(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn)
            {
                DialogViewModel? data = ((Button)e.Source).DataContext as DialogViewModel;
                if(data != null)
                {
                    await TempDataGetter.EditData(data);
                    shitModel model = List.Where(i => i.id == data.id).First();
                    model.userName = data.Username;
                    model.passWord = data.Password;
                    ((NewUserDialogBox)((Grid)btn.Parent).Parent).Close();
                }
            }
        }

        public async void DeleteData(shitModel data)
        {
            List.Remove(data);
            await TempDataGetter.DeleteData(data);
        }
        public async void CreateNewUser(object sender, RoutedEventArgs e)
        {
            if(sender is Button obj)
            {
                DialogViewModel data = (DialogViewModel)((Button)e.Source).DataContext;
                await TempDataGetter.CreateNewUser(data);
                ((NewUserDialogBox)((Grid)obj.Parent).Parent).Close();
            }
        }
    }
}
