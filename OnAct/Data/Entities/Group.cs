using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OnAct.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string AgeGroup { get; set; }

        [MaxLength(7)]
        public string[] StartTimes { get; set; }

        [MaxLength(7)]
        public string[] EndTimes { get; set; }

        [MaxLength(7)]
        public int[] Days { get; set; }

        public bool IsFull  { get; set; }

 
        public DateTime CreatedDate { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

    }
}
