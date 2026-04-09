using FinFlow.Application.Interfaces.Settings;
using FinFlow.Domain.Models;
using FinFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Infrastructure.Repositories.Settings
{
    public class UserSettingsRepository : IUserSettingsRepository
    {
        private readonly FinFlowDbContext _context; 

        public UserSettingsRepository(FinFlowDbContext context)
        {
            _context = context;
        }

        public async Task<UserSettings> GetUserSettingsAsync()
        {
           var settings = await _context.UserSettings.FirstOrDefaultAsync();
           if (settings != null) return settings;

           // create default settings if none exists
           var defaultSettings = new UserSettings
           {
               Id = Guid.NewGuid(),
               Income = 0m,
               FixedExpensesThresholdPercent = 33,
               EmergencyFundTarget = 0m,
           };

           await _context.UserSettings.AddAsync(defaultSettings);
           await _context.SaveChangesAsync();

           return defaultSettings;
        }

        public async Task SaveAsync(UserSettings settings)
        {
            if (settings.Id == Guid.Empty)
            {
                settings.Id = Guid.NewGuid();
                await _context.UserSettings.AddAsync(settings);
            }
            else
            {
                var entry = _context.Entry(settings);
                if (entry.State == EntityState.Detached)
                {
                    // attach and mark modified
                    _context.UserSettings.Attach(settings);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    _context.UserSettings.Update(settings);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
