using CAGED.Commands;
using CAGED.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace CAGED.ViewModel.IntroCourse
{
    public class IntroModalViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        public string IntroParaOne { get; set; }
        public string SetImageOne { get; set; }


        public string SubmitBtnText { get; private set; }
        public ICommand SubmitBtnCommand { get; private set; }

        public string ProceedBtnText { get; private set; }
        public ICommand ProceedBtnCommand { get; private set; }

        #region Button Visiblity Properties
        private bool submitBtnVisible = true;
        private bool proceedBtnVisible = false;

        public bool SubmitBtnVisible
        {

            get
            {
                return submitBtnVisible;
            }
            set
            {
                submitBtnVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SubmitBtnVisible"));
            }
        }

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


        #region Collections
        private ObservableCollection<string> _chords;
        public ObservableCollection<string> Chords
        {
            get
            {
                return _chords;
            }
            set
            {
                _chords = value;
            }
        }
        #endregion

        #region Getters/Setters

        private string selectedChordOne = "";
        private string selectedChordTwo = "";
        private string selectedChordThree = "";

        public string SelectedChordOne
        {

            get
            {
                return selectedChordOne;
            }
            set
            {
                selectedChordOne = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedChordOne"));
            }
        }

        public string SelectedChordTwo
        {

            get
            {
                return selectedChordTwo;
            }
            set
            {
                selectedChordTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedChordTwo"));
            }
        }

        public string SelectedChordThree
        {

            get
            {
                return selectedChordThree;
            }
            set
            {
                selectedChordThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedChordThree"));
            }
        }
        #endregion
        public IntroModalViewModel()
        {
            /*IntroParaOne = "Look at the Chords below; Select the answer giving the correct Chord names" +
                "\n\nIf you don't know the answer, dont worry - Have a go anyway";

            SetImageOne = "CAD.png";*/

            PopulateElements();

            Chords = new ObservableCollection<string>
            {
                "C Major, A Major, D Major",

                "E Major, G Major, D Major",

                "F Major, B Major, D Major"
            };

            SubmitBtnText = "Submit";
            SubmitBtnCommand = new RelayCommand(submitBtn);

            ProceedBtnText = "Proceed";
            ProceedBtnCommand = new RelayCommand(proceedBtn);
        }

        public void submitBtn()
        {
            if (SelectedChordOne.Equals("Choose An Answer"))
            {
                App.Current.MainPage.DisplayAlert("Wrong Input", "Select an answer for each shape", "OK");
            }

            if (SelectedChordOne.Equals("C Major, A Major, D Major"))
            {
                App.Current.MainPage.DisplayAlert("Done", "WELL DONE", "OK");

                SubmitBtnVisible = false;

                ProceedBtnVisible = true;
            }

            else
            {
                App.Current.MainPage.DisplayAlert("WRONG", "WRONG", "OK");
            }
        }

        public void proceedBtn()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void PopulateElements()
        {
            var assembly = typeof(ProfilePage).GetTypeInfo().Assembly;
            System.IO.Stream stream = assembly.GetManifestResourceStream("CAGED.Data.LessonData.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                var rootObjects = JsonConvert.DeserializeObject<List<LessonModel>>(json);

                foreach (var rootObject in rootObjects)
                {
                    if (rootObject.lessonID == 0 && rootObject.pageID == 2)
                    {
                        IntroParaOne = rootObject.paraOne;
                        SetImageOne = rootObject.findImage;

                    }

                    


                }
            }
        }

    }

}
