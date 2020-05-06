
using CAGED.Commands;
using CAGED.Model;
using CAGED.View;
using CAGED.View.IntroCourse;
using CAGED.View.Login;
using CAGED.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED.ViewModel
{
    public class CoursesPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Popup Handlers
        private bool displayPopup;
        public bool DisplayPopup
        {
            get
            {
                return displayPopup;
            }
            set
            {
                displayPopup = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayPopup"));
            }
        }

        private bool displayPopupTwo;
        public bool DisplayPopupTwo
        {
            get
            {
                return displayPopupTwo;
            }
            set
            {
                displayPopupTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayPopupTwo"));
            }
        }

        private bool displayIntroPopup;
        public bool DisplayIntroPopup
        {
            get
            {
                return displayIntroPopup;
            }
            set
            {
                displayIntroPopup = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayIntroPopup"));
            }
        }
        public ICommand PopupAcceptCommand { get; set; }
        public ICommand PopupUpdateCommand { get; set; }
        public ICommand PopupIntroCommand { get; set; }
        #endregion



        #region textCardOne
        public string IntroHeader1 { get; set; }
        private int progressBar = 0;
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

        public string Header2 { get; set; }
        public string IntroBlurb { get; set; }
        #endregion

        #region Set Visibility Properties
        private bool setSLVisible = true;
        public bool SetSLVisible
        {

            get
            {
                return setSLVisible;
            }
            set
            {
                setSLVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetSLVisible"));
            }
        }

        private bool editCourseVisible = false;
        public bool EditCourseVisible
        {

            get
            {
                return editCourseVisible;
            }
            set
            {
                editCourseVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EditCourseVisible"));
            }
        }

        private bool setNewCourseVisible = false;
        public bool SetNewCourseVisible
        {

            get
            {
                return setNewCourseVisible;
            }
            set
            {
                setNewCourseVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetNewCourseVisible"));
            }
        }

        private string setPadlockOne = "padlock.png";
        public string SetPadlockOne
        {

            get
            {
                return setPadlockOne;
            }
            set
            {
                setPadlockOne = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetPadlockOne"));
            }
        }
        private string setPadlockTwo = "padlock.png";
        public string SetPadlockTwo
        {

            get
            {
                return setPadlockTwo;
            }
            set
            {
                setPadlockTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetPadlockTwo"));
            }
        }
        private string setPadlockThree = "padlock.png";
        public string SetPadlockThree
        {

            get
            {
                return setPadlockThree;
            }
            set
            {
                setPadlockThree = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetPadlockThree"));
            }
        }
        private string setPadlockFour = "padlock.png";
        public string SetPadlockFour
        {

            get
            {
                return setPadlockFour;
            }
            set
            {
                setPadlockFour = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetPadlockFour"));
            }
        }
        private string setPadlockFive = "padlock.png";
        public string SetPadlockFive
        {

            get
            {
                return setPadlockFive;
            }
            set
            {
                setPadlockFive = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetPadlockFive"));
            }
        }
        private string setPadlockSix = "padlock.png";
        public string SetPadlockSix
        {

            get
            {
                return setPadlockSix;
            }
            set
            {
                setPadlockSix = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetPadlockSix"));
            }
        }
        #endregion

        #region textCardTwo
        public string CourseOneHeader1 { get; set; }
        public string CourseOneBlurb { get; set; }
        /*private string courseOneHeader1;
        public string CourseOneHeader1
        {
            get { return courseOneHeader1; }
            set
            {
                courseOneHeader1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CourseOneHeader1"));
            }
        }
        private string courseOneBlurb;
        public string CourseOneBlurb
        {
            get { return courseOneBlurb; }
            set
            {
                courseOneBlurb = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CourseOneBlurb"));
            }
        }*/
        #endregion

        #region buttonTextIntro
        public string IntroBtn { get; set; }
        public string LessonOneBtn { get; set; }
        public string LessonTwoBtn { get; set; }
        public string LessonThreeBtn { get; set; }
        public string LessonFourBtn { get; set; }
        public string LessonFiveBtn { get; set; }
        public string IntroAsssessmentBtn { get; set; }
        #endregion

        #region buttonImages
        public string CardOneImage { get; set; }
        public string CardTwoImage { get; set; }

        #endregion

        #region buttonTextCOne
        public string COneIntroBtn { get; set; }
        public string COneLessonOneBtn { get; set; }
        public string COneLessonTwoBtn { get; set; }
        public string COneLessonThreeBtn { get; set; }
        public string COneLessonFourBtn { get; set; }
        public string COneLessonFiveBtn { get; set; }
        /*private string cOneIntroBtn;
        public string COneIntroBtn
        {
            get { return cOneIntroBtn; }
            set
            {
                cOneIntroBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("COneIntroBtn"));
            }
        }
        private string cOneLessonOneBtn;
        public string COneLessonOneBtn
        {
            get { return cOneLessonOneBtn; }
            set
            {
                cOneLessonOneBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("COneLessonOneBtn"));
            }
        }
        private string cOneLessonTwoBtn;
        public string COneLessonTwoBtn
        {
            get { return cOneLessonTwoBtn; }
            set
            {
                cOneLessonTwoBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("COneLessonTwoBtn"));
            }
        }
        private string cOneLessonThreeBtn;
        public string COneLessonThreeBtn
        {
            get { return cOneLessonThreeBtn; }
            set
            {
                cOneLessonThreeBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("COneLessonThreeBtn"));
            }
        }
        private string cOneLessonFourBtn;
        public string COneLessonFourBtn
        {
            get { return cOneLessonFourBtn; }
            set
            {
                cOneLessonFourBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("COneLessonFourBtn"));
            }
        }
        private string cOneLessonFiveBtn;
        public string COneLessonFiveBtn
        {
            get { return cOneLessonFiveBtn; }
            set
            {
                cOneLessonFiveBtn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("COneLessonFiveBtn"));
            }
        }*/
        public string LogoutBtn { get; set; }
        #endregion

        #region commands
        public ICommand IntroLessonBtnCommand { get; private set; }
        public ICommand IntroLessonOneCommand { get; private set; }
        public ICommand IntroLessonTwoCommand { get; private set; }
        public ICommand IntroLessonThreeCommand { get; private set; }
        public ICommand IntroLessonFourCommand { get; private set; }
        public ICommand IntroLessonFiveCommand { get; private set; }
        public ICommand IntroAssessmentCommand { get; private set; }
        public ICommand LogoutBtnCommand { get; private set; }
        public ICommand SetNewCourseCommand { get; private set; }
        public ICommand UpdateNewCourseCommand { get; private set; }        
        public ICommand OpenPopupCommand { get; set; }
        #endregion

        #region Constructor
        public CoursesPageViewModel()
        {
            BuildCourses();

            LogoutBtn = "Logout";

            IntroLessonBtnCommand = new RelayCommand(IntroBtnClick);
            IntroLessonOneCommand = new RelayCommand(IntroLessonOneBtnClick);
            IntroLessonTwoCommand = new RelayCommand(IntroLessonTwoBtnClick);
            IntroLessonThreeCommand = new RelayCommand(IntroLessonThreeBtnClick);
            IntroLessonFourCommand = new RelayCommand(IntroLessonFourBtnClick);
            IntroLessonFiveCommand = new RelayCommand(IntroLessonFiveBtnClick);
            IntroAssessmentCommand = new RelayCommand(IntroAssessBtnClick);
            LogoutBtnCommand = new RelayCommand(LogoutBtnClick);
            SetNewCourseCommand = new RelayCommand(SetCourseBtnClick);
            UpdateNewCourseCommand = new RelayCommand(UpdateCourseBtnClick);
            PopupAcceptCommand = new Command(PopupAccept);
            PopupUpdateCommand = new Command(PopupUpdate);
            PopupIntroCommand = new Command(PopupIntroContinue);

        }
        #endregion

        #region User Logout
        private void LogoutBtnClick()
        {

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();

                var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET CurrentUser = ? WHERE CurrentUser = ?", "false", "true");


                App.Current.MainPage.DisplayAlert("Success", "User Logged Out", "OK");

            }

            App.Current.MainPage.Navigation.PushAsync(new MainPage());


        }
        #endregion


        private void SetCourseBtnClick()
        {
            
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var myquery = conn.Table<RegisterModel>().ToList();
                
                foreach (var rootObject in myquery)
                {
                    
                    if (rootObject.CurrentUser == "true" && rootObject.IsAdmin == true)
                    {
                        DisplayPopup = true;
                        SetNewCourseVisible = true;
                    }                    
                }
            }
        }

        private void UpdateCourseBtnClick()
        {

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //conn.CreateTable<RegisterModel>();


                var myquery = conn.Table<RegisterModel>().ToList();


                foreach (var rootObject in myquery)
                {

                    if (rootObject.CurrentUser == "true" && rootObject.IsAdmin == true)
                    {
                        //SetSLVisible = false;
                        DisplayPopupTwo = true;
                        //OpenPopupCommand = new Command(OpenPopup);
                        SetNewCourseVisible = true;
                    }
                }
                //App.Current.MainPage.DisplayAlert("Success", "Course Created", "OK");
            }
        }

        private void QueryIfCourseExists()
        {
            
            
                using (var conn = new SQLiteConnection(App.DatabaseLocation))
                {
                     var queryCourses = conn.Query<CourseModel>("SELECT name FROM sqlite_master WHERE type='table' AND name='CourseModel'; ");
                     var rowCount = conn.Table<CourseModel>().Count();
                //Write code if table exists 

                if ((rowCount > 1))
                    {
                        //App.Current.MainPage.DisplayAlert("IT DOES!","Course One Exists","OK");
                    }

                }   
        }

        #region Set Popup Update Functionality
        private void PopupUpdate()
        {

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<CourseModel>();


                var updateCourseTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET CourseTitle = ? WHERE CourseID = ?", CourseOneHeader1, 2);
                var updateSetImage = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET SetImage = ? WHERE CourseID = ?", "treblesmall.png", 2);
                var updateSetBlurb = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET SetBlurb = ? WHERE CourseID = ?", CourseOneBlurb, 2);
                var updateCourseIntroLessonTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET CourseIntroLessonTitle = ? WHERE CourseID = ?", COneIntroBtn, 2);
                var updateLessonOneTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET LessonOneTitle = ? WHERE CourseID = ?", COneLessonOneBtn, 2);
                var updateLessonTwoTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET LessonTwoTitle = ? WHERE CourseID = ?", COneLessonTwoBtn, 2);
                var updateLessonThreeTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET LessonThreeTitle = ? WHERE CourseID = ?", COneLessonThreeBtn, 2);
                var updateLessonFourTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET LessonFourTitle = ? WHERE CourseID = ?", COneLessonFourBtn, 2);
                var updateLessonFiveTitle = conn.ExecuteScalar<CourseModel>("UPDATE CourseModel SET LessonFiveTitle = ? WHERE CourseID = ?", COneLessonFiveBtn, 2);

            }

            App.Current.MainPage.DisplayAlert("Done", "Course Updated", "OK");
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        #endregion

        #region Set Popup Save Functionality
        private void PopupAccept()
        {
            // Method updates course database with user input details
            // from popup, creating a new course object in the process
            CourseModel registerAccount = new CourseModel
            {

                CourseTitle = CourseOneHeader1,
                SetImage = "treblesmall.png",
                SetBlurb = CourseOneBlurb,
                CourseIntroLessonTitle = COneIntroBtn,
                LessonOneTitle = COneLessonOneBtn,
                LessonTwoTitle = COneLessonTwoBtn,
                LessonThreeTitle = COneLessonThreeBtn,
                LessonFourTitle = COneLessonFourBtn,
                LessonFiveTitle = COneLessonFiveBtn
        };

            // Create a new table for the newly created course 
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //conn.DropTable<RegisterModel>();
                conn.CreateTable<RegisterModel>();
                int rows = conn.Insert(registerAccount);


                if (rows > 0)
                {
                    App.Current.MainPage.DisplayAlert("Success", "Course Created Succesfully", "OK");
                    App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Failure", "Course Creation Failed", "OK");
                }
            } 
        }
        #endregion

        #region Set introPopup Continue Functionality
        private void PopupIntroContinue()
        {
            int lessonValue = 0;
            App.Current.MainPage.Navigation.PushAsync(new IntroOneView(lessonValue));
        }
        #endregion

        #region Navigation
        private void IntroBtnClick()
        {

            //App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
            //SetSLVisible = false;

            DisplayIntroPopup = true;
        }

        private void IntroLessonOneBtnClick()
        {

            //App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
            //SetSLVisible = false;
            int lessonValue = 1;
            App.Current.MainPage.Navigation.PushAsync(new LessonOneView(lessonValue));
        }

        private void IntroLessonTwoBtnClick()
        {

            //App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
            //SetSLVisible = false;
            int lessonValue = 2;
            App.Current.MainPage.Navigation.PushAsync(new LessonTwoView(lessonValue));


        }

        private void IntroLessonThreeBtnClick()
        {

            //App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
            //SetSLVisible = false;
            int lessonValue = 3;
            App.Current.MainPage.Navigation.PushAsync(new LessonThreeView(lessonValue));


        }

        private void IntroLessonFourBtnClick()
        {

            //App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
            //SetSLVisible = false;
            int lessonValue = 4;
            App.Current.MainPage.Navigation.PushAsync(new LessonFourView(lessonValue));


        }

        private void IntroLessonFiveBtnClick()
        {

            //App.Current.MainPage.DisplayAlert("Failure", "Login details incorrect", "OK");
            //SetSLVisible = false;
            int lessonValue = 5;
            App.Current.MainPage.Navigation.PushAsync(new LessonFiveView(lessonValue));


        }

        private void IntroAssessBtnClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new IntroAssessment());
            //App.Current.MainPage.DisplayAlert("","BUTTON WORKS","OK");
        }
        #endregion

        #region Build first course
        public void CheckCourseTableExists()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    //Student is table name ,replace student with your table name
                    var existTable = conn.Query<CourseModel>("SELECT name FROM sqlite_master WHERE type='table' AND name='CourseModel'; ");
                    if ((existTable.Count > 0))
                    {
                        //Write code if table exists 
                        //App.Current.MainPage.DisplayAlert("", "EXISTS", "OK");
                    }
                    
                    if ((existTable.Count <= 0))
                    {
                        //App.Current.MainPage.DisplayAlert("", "DOESNT EXIST", "OK");

                        CourseModel createCourse = new CourseModel
                        {

                            CourseTitle = "Intro Course: ",
                            SetImage = "smallguitar.png",
                            SetBlurb = "Simple lessons introducing the five chords of the CAGED system - C, A, G, E, D",
                            CourseIntroLessonTitle = "Introduction",
                            LessonOneTitle = "Lesson 1 - C Shape",
                            LessonTwoTitle = "Lesson 2 - A Shape",
                            LessonThreeTitle = "Lesson 3 - G Shape",
                            LessonFourTitle = "Lesson 4 - E Shape",
                            LessonFiveTitle = "Lesson 5 - D Shape",
                            AssessmentTitle = "Assessment"
                            //AssessmentTitle = SetLessonSixProgress
                        };

                        //conn.DropTable<RegisterModel>();
                        conn.CreateTable<CourseModel>();
                        int rows = conn.Insert(createCourse);


                        if (rows > 0)
                        {
                            App.Current.MainPage.DisplayAlert("Success", "Account Created Succesfully", "OK");

                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("Failure", "Account Creation Failed", "OK");
                        }
                    }
                    //QueryIfCourseExists();
                }
                catch (Exception Ex)
                {
                }
            }
        }
        #endregion

        #region Read the database
        public void ReadDatabase()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();
                var rowCount = conn.Table<CourseModel>().Count();
                var myquery = conn.Table<RegisterModel>().ToList();
                // Searches through list to find current user, and sets the user's progress
                // based on the lesson parameters which are equal to true
                foreach (var rootObject in myquery)
                {
                    if (rootObject.CurrentUser == "true")
                    {
                        if (rootObject.IntroOneProgress == "true")
                        {
                            ProgressBar = 14; // Sets value of the progress bar 
                            SetPadlockOne = ""; // Removes padlock image from next lesson
                        }
                        if (rootObject.LessonOneProgress == "true")
                        {
                            ProgressBar = 28;
                            SetPadlockTwo = "";
                        }
                        if (rootObject.LessonTwoProgress == "true")
                        {
                            ProgressBar = 42;
                            SetPadlockThree = "";
                        }
                        if (rootObject.LessonThreeProgress == "true")
                        {

                            ProgressBar = 56;
                            SetPadlockFour = "";
                        }
                        if (rootObject.LessonFourProgress == "true")
                        {
                            ProgressBar = 70;
                            SetPadlockFive = "";
                        }
                        if (rootObject.LessonFiveProgress == "true")
                        {
                            ProgressBar = 84;
                            SetPadlockSix = "";
                        }
                        if (rootObject.IntroAssProgress == "true")
                        {
                            ProgressBar = 100;

                        }
                    }
                    if (rootObject.CurrentUser == "true" && rootObject.IsAdmin == false)
                    {
                        SetSLVisible = false;
                        EditCourseVisible = false;
                        SetNewCourseVisible = false;

                        if ((rowCount > 1))
                        {
                            SetNewCourseVisible = true;

                        }
                    }
                    if (rootObject.CurrentUser == "true" && rootObject.IsAdmin == true)
                    {
                        SetSLVisible = true;
                        EditCourseVisible = false;
                        SetNewCourseVisible = false;

                        if ((rowCount > 1))
                        {
                            SetSLVisible = false;
                            EditCourseVisible = true;
                            SetNewCourseVisible = true;

                        }
                    }
                }
            }
        }
        #endregion

        #region Build Courses
        public void BuildCourses()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var myquery = conn.Table<CourseModel>().ToList();

                foreach (var rootObject in myquery)
                {
                    if (rootObject.CourseID == 1)
                    {
                        IntroHeader1 = rootObject.CourseTitle;
                        CardOneImage = rootObject.SetImage;
                        IntroBlurb = rootObject.SetBlurb;
                        IntroBtn = rootObject.CourseIntroLessonTitle;
                        LessonOneBtn = rootObject.LessonOneTitle;
                        LessonTwoBtn = rootObject.LessonTwoTitle;
                        LessonThreeBtn = rootObject.LessonThreeTitle;
                        LessonFourBtn = rootObject.LessonFourTitle;
                        LessonFiveBtn = rootObject.LessonFiveTitle;

                    }

                    if (rootObject.CourseID == 2)
                    {
                        CourseOneHeader1 = rootObject.CourseTitle;
                        CardTwoImage = rootObject.SetImage;
                        CourseOneBlurb = rootObject.SetBlurb;
                        COneIntroBtn = rootObject.CourseIntroLessonTitle;
                        COneLessonOneBtn = rootObject.LessonOneTitle;
                        COneLessonTwoBtn = rootObject.LessonTwoTitle;
                        COneLessonThreeBtn = rootObject.LessonThreeTitle;
                        COneLessonFourBtn = rootObject.LessonFourTitle;
                        COneLessonFiveBtn = rootObject.LessonFiveTitle;
                    }

                }
            }
        }
        #endregion

        private async Task DelayedWork()
        {
            await Task.Delay(1000);
        }
    }
}
