using CAGED.Commands;
using CAGED.Model;
using CAGED.View;
using SQLite;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CAGED.ViewModel.IntroCourse
{
    public class IntroAssessmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int correctAnsCount = 0;
        public int CorrectAnsCount
        {
            get { return correctAnsCount; }
            set
            {
                correctAnsCount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CorrectAnsCount"));
            }
        }


        #region Getters/Setters for Question One
        private bool enableSubmitBtn = true;
        public bool EnableSubmitBtn
        {
            get { return enableSubmitBtn; }
            set
            {
                enableSubmitBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnableSubmitBtn"));
            }
        }

        private bool qOneIsChecked = false;
        public bool QoneIsChecked
        {
            get { return qOneIsChecked; }
            set
            {
                qOneIsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QoneIsChecked"));
            }
        }

        private bool qOneIsCheckedTwo = false;
        public bool QoneIsCheckedTwo
        {
            get { return qOneIsCheckedTwo; }
            set
            {
                qOneIsCheckedTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QoneIsCheckedTwo"));
            }
        }

        private bool qOneIsCheckedThree = false;
        public bool QoneIsCheckedThree
        {
            get { return qOneIsCheckedThree; }
            set
            {
                qOneIsCheckedThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QoneIsCheckedThree"));
            }
        }
        #endregion

        #region Getters/Setters for Question two
        private bool enableSubmitBtnTwo = true;
        public bool EnableSubmitBtnTwo
        {
            get { return enableSubmitBtnTwo; }
            set
            {
                enableSubmitBtnTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnableSubmitBtnTwo"));
            }
        }

        private bool qTwoIsChecked = false;
        public bool QTwoIsChecked
        {
            get { return qTwoIsChecked; }
            set
            {
                qTwoIsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QTwoIsChecked"));
            }
        }

        private bool qTwoIsCheckedTwo = false;
        public bool QTwoIsCheckedTwo
        {
            get { return qTwoIsCheckedTwo; }
            set
            {
                qTwoIsCheckedTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QTwoIsCheckedTwo"));
            }
        }

        private bool qTwoIsCheckedThree = false;
        public bool QTwoIsCheckedThree
        {
            get { return qTwoIsCheckedThree; }
            set
            {
                qTwoIsCheckedThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QTwoIsCheckedThree"));
            }
        }
        #endregion

        #region Getters/Setters for Question three
        private bool enableSubmitBtnThree = true;
        public bool EnableSubmitBtnThree
        {
            get { return enableSubmitBtnThree; }
            set
            {
                enableSubmitBtnThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnableSubmitBtnThree"));
            }
        }

        private bool qThreeIsChecked = false;
        public bool QThreeIsChecked
        {
            get { return qThreeIsChecked; }
            set
            {
                qThreeIsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QThreeIsChecked"));
            }
        }

        private bool qThreeIsCheckedTwo = false;
        public bool QThreeIsCheckedTwo
        {
            get { return qThreeIsCheckedTwo; }
            set
            {
                qThreeIsCheckedTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QThreeIsCheckedTwo"));
            }
        }

        private bool qThreeIsCheckedThree = false;
        public bool QThreeIsCheckedThree
        {
            get { return qThreeIsCheckedThree; }
            set
            {
                qThreeIsCheckedThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QThreeIsCheckedThree"));
            }
        }
        #endregion

        #region Getters/Setters for Question four
        private bool enableSubmitBtnFour = true;
        public bool EnableSubmitBtnFour
        {
            get { return enableSubmitBtnFour; }
            set
            {
                enableSubmitBtnFour = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnableSubmitBtnFour"));
            }
        }

        private bool qFourIsChecked = false;
        public bool QFourIsChecked
        {
            get { return qFourIsChecked; }
            set
            {
                qFourIsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QFourIsChecked"));
            }
        }

        private bool qFourIsCheckedTwo = false;
        public bool QFourIsCheckedTwo
        {
            get { return qFourIsCheckedTwo; }
            set
            {
                qFourIsCheckedTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QFourIsCheckedTwo"));
            }
        }

        private bool qFourIsCheckedThree = false;
        public bool QFourIsCheckedThree
        {
            get { return qFourIsCheckedThree; }
            set
            {
                qFourIsCheckedThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QFourIsCheckedThree"));
            }
        }
        #endregion

        #region Getters/Setters for Question five
        private bool enableSubmitBtnFive = true;
        public bool EnableSubmitBtnFive
        {
            get { return enableSubmitBtnFive; }
            set
            {
                enableSubmitBtnFive = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnableSubmitBtnFive"));
            }
        }

        private bool qFiveIsChecked = false;
        public bool QFiveIsChecked
        {
            get { return qFiveIsChecked; }
            set
            {
                qFiveIsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QFiveIsChecked"));
            }
        }

        private bool qFiveIsCheckedTwo = false;
        public bool QFiveIsCheckedTwo
        {
            get { return qFiveIsCheckedTwo; }
            set
            {
                qFiveIsCheckedTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QFiveIsCheckedTwo"));
            }
        }

        private bool qFiveIsCheckedThree = false;
        public bool QFiveIsCheckedThree
        {
            get { return qFiveIsCheckedThree; }
            set
            {
                qFiveIsCheckedThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QFiveIsCheckedThree"));
            }
        }
        #endregion


        public ICommand SubmitBtnCommand { get; set; }
        public ICommand ProceedBtnCommand { get; set; }
        public ICommand ProceedTwoBtnCommand { get; set; }
        public ICommand ProceedThreeBtnCommand { get; set; }
        public ICommand ProceedFourBtnCommand { get; set; }
        public ICommand ProceedFiveBtnCommand { get; set; }


        public IntroAssessmentViewModel()
        {
            SubmitBtnCommand = new RelayCommand(SubmitBtnClick);
            ProceedBtnCommand = new RelayCommand(ProceedBtnClick);
            ProceedTwoBtnCommand = new RelayCommand(ProceedBtnTwoClick);
            ProceedThreeBtnCommand = new RelayCommand(ProceedBtnThreeClick);
            ProceedFourBtnCommand = new RelayCommand(ProceedBtnFourClick);
            ProceedFiveBtnCommand = new RelayCommand(ProceedBtnFiveClick);
        }

        private async void SubmitBtnClick()
        {
            if (CorrectAnsCount >= 3)
            {
                string total = "You got " + CorrectAnsCount.ToString() + " correct, well done!";

                await App.Current.MainPage.DisplayAlert("", total, "OK");

                UpdateDatabase();

                //await DelayedWork();

                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }

            if (CorrectAnsCount < 3)
            {
                string total = "You got " + CorrectAnsCount.ToString() + "correct, you need 3 or more to proceed\n\n" +
                    "Try repeating the materials then try again";

                await App.Current.MainPage.DisplayAlert("", total, "OK");

                await DelayedWork();
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }

        private void ProceedBtnClick()
        {
            if (QoneIsChecked == true && QoneIsCheckedTwo == false && QoneIsCheckedThree == false)
            {
                CorrectAnsCount = CorrectAnsCount + 1;
            }

            EnableSubmitBtn = false;

        }

        private void ProceedBtnTwoClick()
        {
            if (QTwoIsChecked == false && QTwoIsCheckedTwo == false && QTwoIsCheckedThree == true)
            {
                CorrectAnsCount = CorrectAnsCount + 1;
            }

            EnableSubmitBtnTwo = false;
        }

        private void ProceedBtnThreeClick()
        {
            if (QThreeIsChecked == false && QThreeIsCheckedTwo == true && QThreeIsCheckedThree == false)
            {
                CorrectAnsCount = CorrectAnsCount + 1;
            }

            EnableSubmitBtnThree = false;
        }

        private void ProceedBtnFourClick()
        {
            if (QFourIsChecked == true && QFourIsCheckedTwo == false && QFourIsCheckedThree == false)
            {
                CorrectAnsCount = CorrectAnsCount + 1;
            }

            EnableSubmitBtnFour = false;
        }

        private void ProceedBtnFiveClick()
        {
            if (QFiveIsChecked == false && QFiveIsCheckedTwo == true && QFiveIsCheckedThree == false)
            {
                CorrectAnsCount = CorrectAnsCount + 1;
            }

            EnableSubmitBtnFive = false;
        }

        public void UpdateDatabase()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();

                var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET IntroAssProgress = ? WHERE CurrentUser = ?", "true", "true");
            }
        }

        private async Task DelayedWork()
        {
            await Task.Delay(500);
        }
    }
}
    

