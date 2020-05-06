using CAGED.Commands;
using CAGED.Model;
using CAGED.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace CAGED.ViewModel.Main
{
    public class ProfilePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Getters / Setters

        private string setNickname = "Nickname";
        public string SetNickname
        {

            get
            {
                return setNickname;
            }
            set
            {
                setNickname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetNickname"));
            }
        }
        /*public string SetIntroCourseProgress { get; set; }
        public string SetIntroOneProgress { get; set; }
        public string SetLessonOneProgress { get; set; }
        public string SetLessonTwoProgress { get; set; }
        public string SetLessonThreeProgress { get; set; }
        public string SetLessonFourProgress { get; set; }
        public string SetLessonFiveProgress { get; set; }*/


        private string setIntroOneProgress = "Incomplete";
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

        private string setIntroCourseProgress = "Incomplete";
        public string SetIntroCourseProgress
        {

            get
            {
                return setIntroCourseProgress;
            }
            set
            {
                setIntroCourseProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetIntroCourseProgress"));
            }
        }

        private string setLessonOneProgress = "Incomplete";
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

        private string setLessonTwoProgress = "Incomplete";
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

        private string setLessonThreeProgress = "Incomplete";
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

        private string setLessonFourProgress = "Incomplete";
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

        private string setLessonFiveProgress = "Incomplete";
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

        private string setAssessmentProgress = "Incomplete";
        public string SetAssessmentProgress
        {

            get
            {
                return setAssessmentProgress;
            }
            set
            {
                setAssessmentProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetAssessmentProgress"));
            }
        }

        #endregion

        public string ClearProgessBtnText { get; private set; }
        public ICommand ClearBtnCommand { get; private set; }


        public ProfilePageViewModel()
        {
            ClearProgessBtnText = "LOGICAL";
            ClearBtnCommand = new RelayCommand(clearProgressBtn);
            //ReadDatabase();
        }
        // Function that will detect the logged in user, and update the user progress
        public void ReadDatabase()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();

                var myquery = conn.Table<RegisterModel>().ToList();

                foreach (var rootObject in myquery) // Search list
                {   // Find the current user, and change binding parameters
                    if (rootObject.CurrentUser == "true")
                    {
                        SetNickname = rootObject.Nickname;

                        if (rootObject.IntroOneProgress == "true")
                        {
                            SetIntroOneProgress = "Complete";
                        }
                        else
                        {
                            SetIntroOneProgress = "Incomplete";
                        }
                        if (rootObject.LessonOneProgress == "true")
                        {
                            SetLessonOneProgress = "Complete";
                        }
                        else
                        {
                            SetLessonOneProgress = "Incomplete";
                        }
                        if (rootObject.LessonTwoProgress == "true")
                        {
                            SetLessonTwoProgress = "Complete";
                        }
                        else
                        {
                            SetLessonTwoProgress = "Incomplete";
                        }
                        if (rootObject.LessonThreeProgress == "true")
                        {

                            SetLessonThreeProgress = "Complete";
                        }
                        else
                        {
                            SetLessonThreeProgress = "Incomplete";
                        }
                        if (rootObject.LessonFourProgress == "true")
                        {
                            SetLessonFourProgress = "Complete";
                        }
                        else
                        {
                            SetLessonFourProgress = "Incomplete";
                        }
                        if (rootObject.LessonFiveProgress == "true")
                        {
                            SetLessonFiveProgress = "Complete";
                        }
                        else
                        {
                            SetLessonFiveProgress = "Incomplete";
                        }
                        if (rootObject.IntroAssProgress == "true")
                        {
                            SetAssessmentProgress = "Complete";
                        }
                        else
                        {
                            SetAssessmentProgress = "Incomplete";
                        }
                    }
                }
            }
        }

        public void clearProgressBtn()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();


                var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET IntroOneProgress = ? ", "false", "true");
                var updateLessonOne = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonOneProgress = ? ", "false", "true");
                var updateLessonTwo = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonTwoProgress = ? ", "false", "true");
                var updateLessonThree = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonThreeProgress = ? ", "false", "true");
                var updateLessonFour = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonFourProgress = ? ", "false", "true");
                var updateLessonFive = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonFiveProgress = ? ", "false", "true");
                var updateAssessment= conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET IntroAssProgress = ? ", "false", "true");

            }

            App.Current.MainPage.DisplayAlert("Done", "Progress Reset", "OK");
            App.Current.MainPage.Navigation.PushAsync(new HomePage());

        }
    }
}

