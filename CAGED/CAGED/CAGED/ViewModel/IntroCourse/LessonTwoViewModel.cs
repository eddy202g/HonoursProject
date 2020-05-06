using CAGED.Commands;
using CAGED.Model;
using CAGED.View;
using CAGED.View.IntroCourse;
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
    public class LessonTwoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int _lessonValue;

        public string SetImageOne { get; set; }

        public string ScreenOneparaOne { get; set; }
        public string ScreenOneparaTwo { get; set; }

        public string ScreenTwoparaOne { get; set; }
        public string ScreenTwoparaTwo { get; set; }

        public string ScreenThreeparaOne { get; set; }
        public string ScreenThreeparaTwo { get; set; }

        public string ScreenFourparaOne { get; set; }
        public string ScreenFourparaTwo { get; set; }
        public string ScreenFourparaTwoPartTwo { get; set; }

        public string ScreenFiveparaOne { get; set; }
        public string ScreenFiveparaTwo { get; set; }

        public string ScreenSixparaOne { get; set; }
        public string ScreenSixparaTwo { get; set; }



        #region Full Getters/Setters
        private string screenFourUserInput = "             ";
        public string ScreenFourUserInput
        {

            get
            {
                return screenFourUserInput;
            }
            set
            {
                screenFourUserInput = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ScreenFourUserInput"));
            }
        }



        private int progressBar = 17;
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

        public string LessonCompleteBtnText { get; private set; }
        public ICommand LessonCompleteBtnCommand { get; private set; }

        public string Part1CompleteBtnText { get; private set; }
        public ICommand Part1CompleteBtnCommand { get; private set; }

        public string Part2CompleteBtnText { get; private set; }
        public ICommand Part2CompleteBtnCommand { get; private set; }

        public string Part3CompleteBtnText { get; private set; }
        public ICommand Part3CompleteBtnCommand { get; private set; }
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
        private bool part4Visible = false;
        public bool Part4Visible
        {

            get
            {
                return part4Visible;
            }
            set
            {
                part4Visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Part4Visible"));
            }
        }
        private bool part5Visible = false;
        public bool Part5Visible
        {

            get
            {
                return part5Visible;
            }
            set
            {
                part5Visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Part5Visible"));
            }
        }
        private bool part6Visible = false;
        public bool Part6Visible
        {

            get
            {
                return part6Visible;
            }
            set
            {
                part6Visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Part6Visible"));
            }
        }
        #endregion

        #region Constructor
        public LessonTwoViewModel(int lessonValue)
        {
            #region Screen One Elements

            _lessonValue = lessonValue;

            /*if (lessonValue.Equals(0))
            {
                App.Current.MainPage.DisplayAlert("OK", "THIS IS LESSON ZERO", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("OK", "THIS IS LESSON ONE", "OK");
            }*/

            PopulateElements(lessonValue);

            Part1CompleteBtnText = "Proceed";
            Part1CompleteBtnCommand = new RelayCommand(partOneComplete);

            Part2CompleteBtnText = "Proceed";
            Part2CompleteBtnCommand = new RelayCommand(partTwoComplete);

            Part3CompleteBtnText = "Proceed";
            Part3CompleteBtnCommand = new RelayCommand(partThreeComplete);




            CorrectAnswerBtnText = "position";
            CorrectAnswerBtnCommand = new RelayCommand(correctAnswerBtn);

            WrongAnswerBtnText = "scale";
            WrongAnswerBtnCommand = new RelayCommand(wrongAnswerBtn);

            ProceedBtnText = "PROCEED";
            ProceedBtnCommand = new RelayCommand(proceedBtn);
            #endregion

            #region Screen Two Elements

            TakeTestBtnText = "Take Test";
            TakeTestBtnCommand = new RelayCommand(takeTestBtn);
            #endregion

            #region Screen Three Elements



            LessonCompleteBtnText = "Complete";
            LessonCompleteBtnCommand = new RelayCommand(LessonCompleteBtn);
            #endregion

        }
        #endregion

        public async void correctAnswerBtn()
        {
            ScreenFourUserInput = "position";

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

        public void partOneComplete()
        {
            Part1Visible = false;
            Part2Visible = true;
            ProgressBar = Convert.ToInt16("34");

        }

        public void partTwoComplete()
        {
            Part1Visible = false;
            Part2Visible = false;
            Part3Visible = true;
            ProgressBar = Convert.ToInt16("51");

        }

        public void partThreeComplete()
        {
            Part1Visible = false;
            Part2Visible = false;
            Part3Visible = false;
            Part4Visible = true;
            ProgressBar = Convert.ToInt16("68");

        }



        public void proceedBtn()
        {
            Part1Visible = false;
            Part2Visible = false;
            Part3Visible = false;
            Part4Visible = false;
            Part5Visible = true;
            ProgressBar = Convert.ToInt16("85");

        }

        public async void takeTestBtn()
        {
            View.IntroCourse.LessonTwoModalView testModal = new LessonTwoModalView("TEST", this);

            await App.Current.MainPage.Navigation.PushModalAsync(testModal);

            await DelayedWork();
            Part1Visible = false;
            Part2Visible = false;
            Part3Visible = false;
            Part4Visible = false;
            Part5Visible = false;
            Part6Visible = true;
            ProgressBar = Convert.ToInt16("100");
        }

        public void LessonCompleteBtn()
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
                    if (lessonValue == 2 && rootObject.lessonID == 2 && rootObject.pageID == 0)
                    {
                        ScreenOneparaOne = rootObject.paraOne;
                        ScreenOneparaTwo = rootObject.paraTwo;
                    }

                    if (lessonValue == 2 && rootObject.lessonID == 2 && rootObject.pageID == 1)
                    {
                        ScreenTwoparaOne = rootObject.paraOne;
                        ScreenTwoparaTwo = rootObject.paraTwo;

                    }

                    if (lessonValue == 2 && rootObject.lessonID == 2 && rootObject.pageID == 3)
                    {
                        ScreenThreeparaOne = rootObject.paraOne;
                        SetImageOne = rootObject.findImage;
                    }

                    if (lessonValue == 2 && rootObject.lessonID == 2 && rootObject.pageID == 4)
                    {
                        ScreenFourparaOne = rootObject.paraOne;
                        ScreenFourparaTwo = rootObject.paraTwo;
                        ScreenFourparaTwoPartTwo = rootObject.extraSentence;
                    }

                    if (lessonValue == 2 && rootObject.lessonID == 2 && rootObject.pageID == 5)
                    {
                        ScreenFiveparaOne = rootObject.paraOne;
                        ScreenFiveparaTwo = rootObject.paraTwo;
                    }

                    if (lessonValue == 2 && rootObject.lessonID == 2 && rootObject.pageID == 6)
                    {
                        ScreenSixparaOne = rootObject.paraOne;
                        ScreenSixparaTwo = rootObject.paraTwo;
                    }
                }
            }
        }


        public void UpdateDatabase()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();

                var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET LessonTwoProgress = ? WHERE CurrentUser = ?", "true", "true");
            }
        }


    }
}
