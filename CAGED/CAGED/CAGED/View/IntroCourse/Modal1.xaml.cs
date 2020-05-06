using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CAGED.View;
using CAGED.View.IntroCourse;
using CAGED.ViewModel.IntroCourse;
using CAGED.ViewModel;

namespace CAGED
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Modal1 : ContentPage
	{
        
        private string v;
        private IntroOneViewModel introOneViewModel;
        
        private LessonTwoViewModel lessonTwoViewModel;
        private LessonThreeViewModel lessonThreeViewModel;
        private LessonFourViewModel lessonFourViewModel;
        private LessonFiveViewModel lessonFiveViewModel;

        IntroModalViewModel introModalVM;
        

        public Modal1(string v, IntroOneViewModel introOneViewModel)
        {
            this.v = v;
            this.introOneViewModel = introOneViewModel;

            

            introModalVM = new IntroModalViewModel();
            InitializeComponent();
            BindingContext = introModalVM;

            
        }

        

        public Modal1(string v, LessonTwoViewModel lessonTwoViewModel)
        {
            this.v = v;
            this.lessonTwoViewModel = lessonTwoViewModel;

            introModalVM = new IntroModalViewModel();
            InitializeComponent();
            BindingContext = introModalVM;
        }

        public Modal1(string v, LessonThreeViewModel lessonThreeViewModel)
        {
            this.v = v;
            this.lessonThreeViewModel = lessonThreeViewModel;

            introModalVM = new IntroModalViewModel();
            InitializeComponent();
            BindingContext = introModalVM;
        }

        public Modal1(string v, LessonFourViewModel lessonFourViewModel)
        {
            this.v = v;
            this.lessonFourViewModel = lessonFourViewModel;

            introModalVM = new IntroModalViewModel();
            InitializeComponent();
            BindingContext = introModalVM;
        }

        public Modal1(string v, LessonFiveViewModel lessonFiveViewModel)
        {
            this.v = v;
            this.lessonFiveViewModel = lessonFiveViewModel;

            introModalVM = new IntroModalViewModel();
            InitializeComponent();
            BindingContext = introModalVM;
        }

    }

   
}