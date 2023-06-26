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
            await TempDataGetter.EditData(data);
            Debug.Print(data.ToString());
        }

        public async void DeleteData(shitModel data)
        {
            List.Remove(data);
            await TempDataGetter.DeleteData(data);
        }
        public async void CreateNewUser(object sender, RoutedEventArgs e)
        {
            shitModel model = new shitModel { userName = "username", passWord = "password" };
            await TempDataGetter.CreateNewUser(model);
            GetData();
        }
    }
}
