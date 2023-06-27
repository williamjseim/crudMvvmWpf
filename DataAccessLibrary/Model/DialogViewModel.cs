namespace DataAccessLibrary
{
    public class DialogViewModel : ObservableObject
    {
        public int id { get; set; }

		public static string usernameWatermark = "Username";

        private string _username = "";
		public string Username
		{
			get { return _username; }
			set { _username = value; OnPropertyChanged(); }
		}


		public static string passwordWatermark = "Password";
		private string _password = "";

		public string Password
		{
			get { return _password; }
			set { _password = value; OnPropertyChanged(); }
		}

	}
}
