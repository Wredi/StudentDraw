﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.ViewModels
{
    class GradeViewModel
    {
        public string Name { get; set; }
        public ObservableCollection<StudentViewModel> Students { get; set; }
    }
}
