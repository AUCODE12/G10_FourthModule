using ChatBot.Dal;
using ChatBot.Dal.Entites;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Bll.Services;

public class SkillService : ISkillService
{
    private readonly MainContext mainContext;

    public SkillService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task<long> AddSkillAsync(Skill skill)
    {
        await mainContext.Skills.AddAsync(skill);
        await mainContext.SaveChangesAsync();
        return skill.SkillId;
    }

    public async Task DeleteSkillAsync(long id, long userInfoId)
    {
        var skill = await mainContext.Skills.FirstOrDefaultAsync(ed => ed.SkillId == id && ed.UserInfoId == userInfoId);

        if (skill == null)
        {
            throw new Exception($"Skill with {id} not found");
        }

        mainContext.Skills.Remove(skill);
        await mainContext.SaveChangesAsync();
    }

    public async Task<ICollection<Skill>> GetSkillsByUserInfoIdAsync(long userInfoId)
    {
        var skills = await mainContext.Skills
                            .Where(e => e.UserInfoId == userInfoId)
                            .ToListAsync();
        return skills ?? new List<Skill>();
    }

    public Task UpdateSkillAsync(Skill skill)
    {
        throw new NotImplementedException();
    }
}
