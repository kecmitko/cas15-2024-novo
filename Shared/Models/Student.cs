﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
