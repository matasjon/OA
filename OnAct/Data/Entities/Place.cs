﻿namespace OnAct.Data.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public int ActivityId { get; set; }
        //public Activity Activity { get; set; }
    }
}
