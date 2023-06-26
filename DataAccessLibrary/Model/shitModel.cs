using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class shitModel : ObservableObject
    {
        public int id { get; set; }

        private string _userName;
        public string userName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }
        private string _passWord;
        public string passWord
        {
            get { return _passWord; }
            set { _passWord = value; OnPropertyChanged(); }
        }


        public override string ToString()
        {
            return $"{id} {userName} {passWord}";
        }
    }
}
