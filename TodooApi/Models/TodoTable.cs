namespace TodoApi.Models
{
    public class TodoTable
    {
        public int id { get; set; }
        public string? name { get; set; }
        public bool? isComplete { get; set; }
        
        public bool? is_deleted{ get; set; }
        public DateTime? deleted_on{ get; set; }
        public DateTime? created_on{get; set; }
        public string? created_by{get; set; }
        public string? deleted_by{get; set; }
        
 
 
    }
}