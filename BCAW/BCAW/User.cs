
namespace BCAW
{
    
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  SurName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        
       
        public Gender? Gender { get; set; }
        public Role? Role { get; set; }
    }
}
