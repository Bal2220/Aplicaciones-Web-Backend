using RetoSem11.Shared.Domain.Model.Entities;
using RetoSem11.Shared.Domain.Repositories;

namespace RetoSem11.Management.Domain.Models.Entities
{
    public enum workType
    {
        Excavation,
        Transport,
        Maintenance
    }
    
    public class Operation : BaseEntity
    {
        public Operation() {}
        
        public Operation(string title, string description, workType type, DateTime date, bool status)
        {
            Title = title;
            Description = description;
            Type = type;
            Date = date;
            Status = status;
            IsActive = true;
            CreatedDate = DateTime.Now;
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public workType Type { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}