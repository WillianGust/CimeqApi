using System.ComponentModel;

namespace CimeqApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string Description { get; set; }
        public DateTime DateOrder { get; set; }
        public double CostOrder { get; set; }
        public Client? Client { get; set; } 
    }
}
