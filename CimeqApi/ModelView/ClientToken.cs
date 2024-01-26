using CimeqApi.Models;

namespace CimeqApi.ModelView

{
    public class ClientToken
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Token { get; set; }
    }
}
