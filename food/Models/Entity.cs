namespace food.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string CreatedByUser { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string ModifiedByuser { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
