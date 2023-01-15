namespace Delivery.DataBase.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
