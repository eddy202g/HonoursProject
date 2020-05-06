using CAGED.Commands;
using CAGED.Model;
using CAGED.View;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CAGED.ViewModel.IntroCourse
{
    public class LessonFiveViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public int _lessonValue;

        public string ScreenOneparaOne { get; set; }
        public string ScreenOneparaTwo { get; set; }
        public string ScreenOneparaTwoPartTwo { get; set; }

        public string ScreenTwoparaOne { get; set; }
        public string ScreenTwoparaTwo { get; set; }

        public string ScreenThreeparaOne { get; set; }
        public string ScreenThreeparaTwo { get; set; }



        #region Full Getters/Setters
        private string screenOneUserInput = "             ";
        public string ScreenOneUserInput
        {

            get
            {
                return screenOneUserInput;
            }
            set
            {
                screenOneUserInput = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ScreenOneUserInput"));
            }
        }



        private int progressBar = 33;
        public int ProgressBar
        {
            get
            {
                return progressBar;
            }
            set
            {
                progressBar = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ProgressBar"));
            }
        }

        /* private Boolean introOneProgress = false;
         public Boolean IntroOneProgress
         {
             get
             {
                 return introOneProgress;
             }
             set
             {
                 introOneProgress = value;
                 PropertyChanged(this, new PropertyChangedEventArgs("IntroOneProgress"));
             }
         }*/

        #endregion

        #region answerButtons
        public string WrongAnswerBtnText { get; private set; }
        public ICommand WrongAnswerBtnCommand { get; private set; }

        public string CorrectAnswerBtnText { get; private set; }
        public ICommand CorrectAnswerBtnCommand { get; private set; }

        public string ProceedBtnText { get; private set; }
        public ICommand ProceedBtnCommand { get; private set; }

        public string TakeTestBtnText { get; private set; }
        public ICommand TakeTestBtnCommand { get; private set; }

        public string IntroCompleteBtnText { get; private set; }
        public ICommand IntroCompleteBtnCommand { get; private set; }
        #endregion

        #region Button Visiblity Properties
        private bool correctAnswerBtnVisible = true;
        public bool CorrectAnswerBtnVisible
        {

            get
            {
                return correctAnswerBtnVisible;
            }
            set
            {
                correctAnswerBtnVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CorrectAnswerBtnVisible"));
            }
        }

        private bool wrongAnwserBtnVisible = true;
        public bool WrongAnwserBtnVisible
        {

            get
            {
                return wrongAnwserBtnVisible;
            }
            set
            {
                wrongAnwserBtnVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WrongAnwserBtnVisible"));
            }
        }

        private bool proceedBtnVisible = false;
        public bool ProceedBtnVisible
        {

            get
            {
                return proceedBtnVisible;
            }
            set
            {
                proceedBtnVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ProceedBtnVisible"));
            }
        }


        #endregion

        #region Page Visiblity Properties
        private bool part1Visible = true;
        public bool Part1Visible
        {

            get
            {
                return part1Visible;
            }
            set
            {
                part1Visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Part1Visible"));
            }
        }

        private bool part3Visible = false;
        public bool Part3Visible
        {

            get
            {
                return part3Visible;
            }
            set
            {
                part3Visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Part3Visible"));
            }
        }

        private bool part2Visible = false;
        public bool Part2Visible
        {

            get
            {
                return part2Visible;
            }
            set
            {
                part2Visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Part2Visible"));
            }
        }
        #endregion

        #region Constructor
        public LessonFiveViewModel(int lessonValue)
        {
            #region Screen One Elements

            _lessonValue = lessonValue;

            if (lessonValue.Equals(0))
            {
                App.Current.MainPage.DisplayAlert("OK", "THIS IS LESSON ZERO", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("OK", "THIS IS LESSON ONE", "OK");
            }

            PopulateElements(lessonValue);

            CorrectAnswerBtnText = "LOGICAL";
            CorrectAnswerBtnCommand = new RelayCommand(correctAnswerBtn);

            WrongAnswerBtnText = "BORING";
            WrongAnswerBtnCommand = new RelayCommand(wrongAnswerBtn);

            ProceedBtnText = "PROCEED";
            ProceedBtnCommand = new RelayCommand(proceedBtn);
            #endregion

            #region Screen Two Elements

            TakeTestBtnText = "Take Test";
            TakeTestBtnCommand = new RelayCommand(takeTestBtn);
            #endregion

            #region Screen Three Elements



            IntroCompleteBtnText = "Complete";
            IntroCompleteBtnCommand = new RelayCommand(introCompleteBtn);
            #endregion

        }
        #endregion

        public async void correctAnswerBtn()
        {
            ScreenOneUserInput = "logical";

            //await delayedWork();

            await App.Current.MainPage.DisplayAlert("Correct Answer", "\nGreat Work!", "OK");
            CorrectAnswerBtnVisible = false;
            WrongAnwserBtnVisible = false;
            ProceedBtnVisible = true;
        }

        public void wrongAnswerBtn()
        {
            App.Current.MainPage.DisplayAlert("Wrong Answer", "\nGive that another try...", "Try Again");
        }

        public void proceedBtn()
        {
            Part1Visible = false;
            Part2Visible = true;
            ProgressBar = Convert.ToInt16("66");


        }

        public async void takeTestBtn()
        {
            Modal1 testModal = new Modal1("TEST", this);

            await App.Current.MainPage.Navigation.PushModalAsync(testModal);

            await DelayedWork();
            Part1Visible = false;
            Part2Visible = false;
            Part3Visible = true;
            ProgressBar = Convert.ToInt16("100");
        }

        public void introCompleteBtn()
        {

            App.Current.MainPage.Navigation.PushAsync(new HomePage());
            UpdateDatabase();
        }

        private async Task DelayedWork()
        {
            await Task.Delay(1000);
        }

        private void PopulateElements(int lessonValue)
        {
            var assembly = typeof(ProfilePage).GetTypeInfo().Assembly;
            System.IO.Stream stream = assembly.GetManifestResourceStream("CAGED.Data.LessonData.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                var rootObjects = JsonConvert.DeserializeObject<List<LessonModel>>(json);

                foreach (var rootObject in rootObjects)
                {
                    if (lessonValue == 5 && rootObject.lessonID == 5 && rootObject.pageID == 0)
                    {
                        ScreenOneparaOne = rootObject.paraOne;
                        ScreenOneparaTwo = rootObject.paraTwo;
                        ScreenOneparaTwoPartTwo = rootObject.extraSentence;
                    }

                    if (lessonValue == 5 && rootObject.lessonID == 5 && rootObject.pageID == 1)
                    {
                        ScreenTwoparaOne = rootObject.paraOne;
                        ScreenTwoparaTwo = rootObject.paraTwo;
                    }

                    if (lessonValue == 5 && rootObject.lessonID == 5 && rootObject.pageID == 3)
                    {
                        ScreenThreeparaOne = rootObject.paraOne;
                        ScreenThreeparaTwo = rootObject.paraTwo;
                    }
                }
            }
        }


        public void UpdateDatabase()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();

                var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonFiveProgress = ? WHERE CurrentUser = ?", "true", "true");
            }
        }


    }
}