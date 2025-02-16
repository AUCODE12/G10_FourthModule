namespace JobPortolSystem.Dal.Entities;

public class Job
{
    public long JobId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }

    public long CompanyId { get; set; }
    public Company Company { get; set; }

    //public ICollection<User> Users { get; set; }
}
