using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StudentDraw.ViewModels
{
    public class StudentViewModel : ObservableObject
    {
        private Models.Student student;
        public Models.Student Model { get { return student; } }

        public string Name
        {
            get => student.Name;
            set
            {
                if (student.Name != value)
                {
                    student.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get => student.Surname;
            set
            {
                if (student.Surname != value)
                {
                    student.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id
        {
            get => student.Id;
            set
            {
                if (student.Id != value)
                {
                    student.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int DrawsTillEnabled
        {
            get => student.DrawsTillEnabled;
            set
            {
                if (student.DrawsTillEnabled != value)
                {
                    student.DrawsTillEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPresent
        {
            get => student.IsPresent;
            set
            {
                if (student.IsPresent != value)
                {
                    student.IsPresent = value;
                    OnPropertyChanged();
                }
            }
        }

        public StudentViewModel(Models.Student student)
        {
            this.student = student;
        }
    }
}
