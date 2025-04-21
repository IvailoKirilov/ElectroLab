namespace ElectroLab.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }          
        public string UserName { get; set; }        
        public DateTime Time { get; set; }          
    }
}
