using CAGED.Model;
using CAGED.ViewModel.Main;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        private ObservableCollection<LessonModel> myrootobject;
        ProfilePageViewModel profileVM;
        public ProfilePage ()
		{

            profileVM = new ProfilePageViewModel();

            InitializeComponent ();


            BindingContext = profileVM;

        }

        protected override void OnAppearing()
        {
            profileVM.ReadDatabase();
            
        }
        /*protected override void OnAppearing()
        {
            base.OnAppearing();
        

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();
                var myquery = conn.Table<RegisterModel>().ToList();
                var myquery2 = conn.Query<RegisterModel>("SELECT * FROM RegisterModel WHERE CurrentUser=?", "true");
                
                //saved_properties_list.ItemsSource = myquery;
            }

            var assembly = typeof(ProfilePage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("CAGED.Data.UserData.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                var rootObjects = JsonConvert.DeserializeObject<List<LessonModel>>(json);
                foreach (var rootObject in rootObjects)
                {
                    if(rootObject.lessonID == 0)
                    {
                        Console.WriteLine("{0} \n {1} \n {2}", rootObject.lessonID, rootObject.paraOne,
                                            rootObject.paraTwo);
                    }
                    
                }
                

            }
    }*/
    }

}