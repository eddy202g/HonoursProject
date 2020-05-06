using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAGED.Model
{
    public class CourseModel
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }

        [MaxLength(15)]
        public string CourseTitle { get; set; }

        [MaxLength(30)]
        public string SetImage { get; set; }

        [MaxLength(100)]
        public string SetBlurb { get; set; }

        [MaxLength(30)]
        public string CourseIntroLessonTitle { get; set; }

        [MaxLength(30)]
        public string LessonOneTitle { get; set; }

        [MaxLength(30)]
        public string LessonTwoTitle { get; set; }

        [MaxLength(30)]
        public string LessonThreeTitle { get; set; }

        [MaxLength(30)]
        public string LessonFourTitle { get; set; }

        [MaxLength(30)]
        public string LessonFiveTitle { get; set; }

        [MaxLength(30)]
        public string AssessmentTitle { get; set; }

        public CourseModel()
        {
            this.CourseTitle = string.Empty;
            this.SetImage = string.Empty;
            this.SetBlurb = string.Empty;
            this.CourseIntroLessonTitle = string.Empty;
            this.LessonOneTitle = string.Empty;
            this.LessonTwoTitle = string.Empty;
            this.LessonThreeTitle = string.Empty;
            this.LessonFourTitle = string.Empty;
            this.LessonFiveTitle = string.Empty;

           // this.AssessmentTitle = string.Empty;

        }
    }
}
