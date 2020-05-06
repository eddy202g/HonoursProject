﻿using CAGED.ViewModel.IntroCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED.View.IntroCourse
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LessonFourView : ContentPage
	{
        LessonFourViewModel lessonFourVM;
        public int _lessonValue;

        public LessonFourView (int lessonValue)
		{
            lessonFourVM = new LessonFourViewModel(lessonValue);
            _lessonValue = lessonValue;

            InitializeComponent();

            BindingContext = lessonFourVM;
        }
	}
}