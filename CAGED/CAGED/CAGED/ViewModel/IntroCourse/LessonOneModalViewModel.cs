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
    class LessonOneModalViewModel : INotifyPropertyChanged
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
        private ObservableCollection<string> _frets;
        public ObservableCollection<string> Frets
        {
            get
            {
                return _frets;
            }
            set
            {
                _frets = value;
            }
        }
        #endregion

        #region Getters/Setters

        private string selectedFretOne = "";
        private string selectedFretTwo = "";
        

        public string SelectedFretOne
        {

            get
            {
                return selectedFretOne;
            }
            set
            {
                selectedFretOne = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedFretOne"));
            }
        }

        public string SelectedFretTwo
        {

            get
            {
                return selectedFretTwo;
            }
            set
            {
                selectedFretTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedFretTwo"));
            }
        }

        
        #endregion
        public LessonOneModalViewModel()
        {
            /*IntroParaOne = "Look at the Chords below; Select the answer giving the correct Chord names" +
                "\n\nIf you don't know the answer, dont worry - Have a go anyway";

            SetImageOne = "CAD.png";*/

            PopulateElements();

            Frets = new ObservableCollection<string>
            {
                "String 5, Fret 3",

                "String 1, Fret 1",

                "String 2, Fret 1",

                "String 4, Fret 3",
            };

            SubmitBtnText = "Submit";
            SubmitBtnCommand = new RelayCommand(submitBtn);

            ProceedBtnText = "Proceed";
            ProceedBtnCommand = new RelayCommand(proceedBtn);
        }

        public void submitBtn()
        {
            if (SelectedFretOne.Equals("Choose An Answer") && SelectedFretTwo.Equals("Choose An Answer"))
            {
                App.Current.MainPage.DisplayAlert("Wrong Input", "Select an answer for each shape", "OK");
            }

            if (SelectedFretOne.Equals("String 5, Fret 3") && SelectedFretTwo.Equals("String 2, Fret 1") || (SelectedFretOne.Equals("String 2, Fret 1") && SelectedFretTwo.Equals("String 5, Fret 3")))
            {
                App.Current.MainPage.DisplayAlert("Correct", "WELL DONE", "OK");


                SubmitBtnVisible = false;

                ProceedBtnVisible = true;
            }

            else
            {
                App.Current.MainPage.DisplayAlert("Incorrect", "Thats not the correct answer, but thats ok. Try revising the section to get the answer", "OK");

                SubmitBtnVisible = false;

                ProceedBtnVisible = true;
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
                    if (rootObject.lessonID == 1 && rootObject.pageID == 2)
                    {
                        IntroParaOne = rootObject.paraOne;
                        SetImageOne = rootObject.findImage;

                    }




                }
            }
        }
    }
}
