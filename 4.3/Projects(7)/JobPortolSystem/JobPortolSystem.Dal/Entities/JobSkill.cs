namespace JobPortolSystem.Dal.Entities;

public class JobSkill
{
    public long JobId { get; set; }
    public Job Job { get; set; }

    public long SkillId { get; set; }
    public Skill Skill { get; set; }
}