using ChatBot.Dal;
using ChatBot.Dal.Entites;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Bll.Services;

public class ExperienceService : IExperienceService
{
    private readonly MainContext mainContext;

    public ExperienceService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task<long> AddExperienceAsync(Experience experience)
    {
        await mainContext.Experiences.AddAsync(experience);
        await mainContext.SaveChangesAsync();
        return experience.ExperienceId;
    }

    public async Task DeleteExperienceAsync(long id, long userInfoId)
    {
        var experience = await mainContext.Experiences.FirstOrDefaultAsync(ed => ed.ExperienceId == id && ed.UserInfoId == userInfoId);

        if (experience == null)
        {
            throw new Exception($"Experience with {id} not found");
        }

        mainContext.Experiences.Remove(experience);
        await mainContext.SaveChangesAsync();
    }

    public async Task<ICollection<Experience>> GetExperiencesByUserInfoIdAsync(long userInfoId)
    {
        var experience = await mainContext.Experiences
                            .Where(e => e.UserInfoId == userInfoId)
                            .ToListAsync();
        return experience ?? new List<Experience>();
    }

    public Task UpdateExperienceAsync(Experience experience)
    {
        throw new NotImplementedException();
    }
}
