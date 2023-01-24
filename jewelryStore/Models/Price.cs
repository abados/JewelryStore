﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jewelryStore.Models
{
    public class Price
    {
        public Price() { Start = DateTime.Now; End = DateTime.Now.AddYears(1); }

        [Key]
        public int ID { get; set; }

        public Item Item { get; set; }

        //[DataType(DataType.DateTime)]
        [Display(Name ="תאריך ושעת התחלה")]
        public DateTime Start { get; set; }
        
        [Display(Name = "תאריך התחלה"), DataType(DataType.Date), NotMapped]

        public DateTime StartDate { get { return Start; } set { Start = new DateTime(value.Year,value.Month,value.Day,Start.Hour,Start.Minute,Start.Second); } }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time), NotMapped]

        public TimeOnly StartTime { get { return new TimeOnly(Start.Hour, Start.Minute); } set { Start = new DateTime(Start.Year, Start.Month, Start.Day, value.Hour, value.Minute, 0); } }

        [Display(Name = "תאריך ושעת סיום")]
        public DateTime End { get; set; }

        [Display(Name = "תאריך סיום"), DataType(DataType.Date), NotMapped]

        public DateTime EndDate { get { return End; } set { End = new DateTime(value.Year, value.Month, value.Day, End.Hour, End.Minute, End.Second); } }

        [Display(Name = "שעת סיום"), DataType(DataType.Time), NotMapped]

        public TimeOnly EndTime { get { return new TimeOnly(End.Hour, End.Minute); } set { End = new DateTime(End.Year, End.Month, End.Day, value.Hour, value.Minute, 0); } }

        [Display(Name = "מחיר")]
        public decimal MyPrice { get; set; }
    }
}