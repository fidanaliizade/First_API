namespace First_API.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public Brand? Brand { get; set; }    
        public Colour? Color { get; set; }    
    }
}
