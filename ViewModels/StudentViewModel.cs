﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StudentDraw.ViewModels
{
    class StudentViewModel : ObservableObject
    {
        private Models.Student student;

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
    }
}