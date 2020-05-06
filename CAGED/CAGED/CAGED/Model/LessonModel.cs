using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAGED.Model
{
    public class LessonModel
    {      
        public int lessonID { get; set; }
        public int courseID { get; set; }
        public int pageID { get; set; }

        public string paraOne { get; set; }
        public string paraTwo { get; set; }
        public string extraSentence { get; set; }
        public string findImage { get; set; }

        public LessonModel()
        {
            this.paraOne = string.Empty;
            this.paraTwo = string.Empty;
        }

        public LessonModel(string paraOne, string paraTwo, string extraSentence)
        {
            this.paraOne = string.Empty;
            this.paraTwo = string.Empty;
            this.extraSentence = string.Empty;
        }

        public LessonModel(string paraOne, string findImage)
        {
            this.paraOne = string.Empty;
            this.findImage = string.Empty;
        }
    }
}
