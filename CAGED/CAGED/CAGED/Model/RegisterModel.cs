using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAGED.Model
{
    public class RegisterModel
    {
        [PrimaryKey, AutoIncrement]
        public int LearnerID { get; set; }

        public bool IsAdmin { get; set; }

        [MaxLength(10)]
        public string Nickname { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [NotNull]
        public string IntroOneProgress { get; set; }
        [NotNull]
        public string LessonOneProgress { get; set; }
        [NotNull]
        public string LessonTwoProgress { get; set; }
        [NotNull]
        public string LessonThreeProgress { get; set; }
        [NotNull]
        public string LessonFourProgress { get; set; }
        [NotNull]
        public string LessonFiveProgress { get; set; }
        [NotNull]
        public string IntroAssProgress { get; set; }

        public string CurrentUser { get; set; }


        public RegisterModel()
        {
            this.Nickname = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}

