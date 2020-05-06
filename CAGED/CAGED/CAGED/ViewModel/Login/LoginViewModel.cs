using CAGED.Commands;
using CAGED.View;
using CAGED.View.Login;
using System;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CAGED.Model;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace CAGED.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region strings
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string password { get; set; }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("password"));
            }
        }

        #endregion

        #region commands
        public string LoginButtonText { get; private set; }
        public ICommand LoginButtonCommand { get; private set; }

        public string BypassButtonText { get; private set; }
        public ICommand BypassButtonCommand { get; private set; }

        public string RegBtnText { get; private set; }
        public ICommand RegBtnCommand { get; private set; }

       
        #endregion

        public LoginViewModel()
        {
            LoginButtonText = "Login";
            LoginButtonCommand = new RelayCommand(LoginButtonClick); // When clicked button will call send method

            BypassButtonText = "Bypass";
            BypassButtonCommand = new RelayCommand(BypassButtonClick);

            RegBtnText = "Register";
            RegBtnCommand = new RelayCommand(RegisterButtonClick);

            
        }

        private void LoginButtonClick()
        {

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //conn.DropTable<RegisterModel>();
                //conn.DropTable<CourseModel>();
                var myquery = conn.Table<RegisterModel>().Where(p => p.Username.Equals(Email) && p.Password.Equals(Password)).FirstOrDefault();
                
                if (myquery != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new HomePage());
                    var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET CurrentUser = ? WHERE Username = ?", "true", Email);


                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
                }
            }
        }

        private void BypassButtonClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private void RegisterButtonClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        public void ReadDatabase()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();
                var myquery = conn.Table<RegisterModel>().ToList();
                // Searches through list to find current user, if any user 
                // still logged in, sets currentUser parameter to false
                foreach (var rootObject in myquery)
                {
                    if (rootObject.CurrentUser == "true")
                    {
                        conn.ExecuteScalar<CourseModel>("UPDATE RegisterModel SET CurrentUser = ?", false);
                    }
                }
            }
        }
    }
}
