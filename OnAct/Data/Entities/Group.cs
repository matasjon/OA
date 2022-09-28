namespace OnAct.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string AgeGroup { get; set; }

        public int[] StartTimes { get; set; }
        public int[] EndTimes { get; set; }

        public int[] Days { get; set; }

        public bool IsFull  { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ActivityId { get; set; }
        public int PlaceId { get; set; }


    }
}
