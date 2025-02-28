namespace ElectroLab.Models
{
    public class Ban
    {
        public int Id { get; set; }
        public string UserId { get; set; }         
        public DateTime BanDate { get; set; }      
        public DateTime? ExpiryDate { get; set; }  
        public string Reason { get; set; }        
        public ApplicationUser User { get; set; } 
    }
}
