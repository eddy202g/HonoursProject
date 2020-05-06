using CAGED.Commands;
using CAGED.Model;
using CAGED.View.Login;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace CAGED.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region strings
        private int setProgress = 0;
        public int SetProgress
        {
            get { return setProgress; }
            set
            {
                setProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetProgress"));
            }
        }

       

        private string setCurrentUser = "false";
        public string SetCurrentUser
        {
            get
            {
                return setCurrentUser;
            }
            set
            {
                setCurrentUser = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetCurrentUser"));
            }
        }


        private string nickname;
        public string RegisterNickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nickname"));
            }
        }

        private string username;
        public string RegisterUsername
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string password { get; set; }
        public string RegisterPassword
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("password"));
            }
        }

        #endregion

        #region LessonProgress
        private string setIntroOneProgress = "false";
        private string setLessonOneProgress = "false";
        private string setLessonTwoProgress = "false";
        private string setLessonThreeProgress = "false";
        private string setLessonFourProgress = "false";
        private string setLessonFiveProgress = "false";
        private string setIntroAssessProgress = "false";

        public string SetIntroOneProgress
        {
            get
            {
                return setIntroOneProgress;
            }
            set
            {
                setIntroOneProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetIntroOneProgress"));
            }
        }

        public string SetLessonOneProgress
        {
            get
            {
                return setLessonOneProgress;
            }
            set
            {
                setLessonOneProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetLessonOneProgress"));
            }
        }
        public string SetLessonTwoProgress
        {
            get
            {
                return setLessonTwoProgress;
            }
            set
            {
                setLessonTwoProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetLessonTwoProgress"));
            }
        }
        public string SetLessonThreeProgress
        {
            get
            {
                return setLessonThreeProgress;
            }
            set
            {
                setLessonThreeProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetLessonThreeProgress"));
            }
        }
        public string SetLessonFourProgress
        {
            get
            {
                return setLessonFourProgress;
            }
            set
            {
                setLessonFourProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetLessonFourProgress"));
            }
        }
        public string SetLessonFiveProgress
        {
            get
            {
                return setLessonFiveProgress;
            }
            set
            {
                setLessonFiveProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetLessonFiveProgress"));
            }
        }
        public string SetIntroAssessProgress
        {
            get
            {
                return setIntroAssessProgress;
            }
            set
            {
                setIntroAssessProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetIntroAssessProgress"));
            }
        }
        #endregion

        #region Checkbox
        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; OnPropertyChanged(); }
        }

        
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region commands
        public string RegisterButtonText { get; private set; }
        public ICommand RegisterButtonCommand { get; private set; }
        #endregion

        public RegisterViewModel()
        {
            RegisterButtonText = "Register Details";
            RegisterButtonCommand = new RelayCommand(RegisterBtnClick); // When clicked button will call send method
        }

        public void RegisterBtnClick()
        {
            
            RegisterModel registerAccount = new RegisterModel
            {
                Nickname = RegisterNickname,
                Username = RegisterUsername,
                Password = RegisterPassword,
                IntroOneProgress = SetIntroOneProgress,
                LessonOneProgress = SetLessonOneProgress,
                LessonTwoProgress = SetLessonTwoProgress,
                LessonThreeProgress = SetLessonThreeProgress,
                LessonFourProgress = SetLessonFourProgress,
                LessonFiveProgress = SetLessonFiveProgress,
                IntroAssProgress = setIntroAssessProgress,
                CurrentUser = SetCurrentUser,
                IsAdmin = IsSelected
            };

            // Updated as result of unit tests - validates the form to ensure the user has
            // filled in all fields - rejects if not 
            if (string.IsNullOrWhiteSpace(RegisterNickname) || string.IsNullOrWhiteSpace(RegisterUsername) || string.IsNullOrWhiteSpace(RegisterPassword))
            {
                App.Current.MainPage.DisplayAlert("Failure", "Account Creation Failed", "OK");
            }

            // Updated as result of unit tests - validates the form to ensure the user has
            // filled in all fields - if it does, carries out registration functinality
            if (!string.IsNullOrWhiteSpace(RegisterNickname) && !string.IsNullOrWhiteSpace(RegisterUsername) && !string.IsNullOrWhiteSpace(RegisterPassword))
            {
                // Create connection to SQLitedatabase and create a new table
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //conn.DropTable<RegisterModel>();
                    conn.CreateTable<RegisterModel>();
                    int rows = conn.Insert(registerAccount);

                    if (rows > 0)
                    {
                        App.Current.MainPage.DisplayAlert("Success", "Account Created Succesfully", "OK");
                        App.Current.MainPage.Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Failure", "Account Creation Failed", "OK");
                    }
                }
            }
        }  
    }
}
