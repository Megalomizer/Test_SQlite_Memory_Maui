﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_SQlite_Memory_Maui.MVVM.Models
{
    [Table("Students")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("name"), Indexed, NotNull]
        public string? Name { get; set; }

        [Unique]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        public int? Age { get; set; }

        [Ignore]
        public bool? OldEnoughToDrink => Age > 17 ? true : false;
    }
}
