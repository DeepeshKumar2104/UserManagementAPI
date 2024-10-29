using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;

namespace UserManagementAPI.Repository.Services
{
    public class EducationRepository:IEducationRepository
    {
        private readonly Project5Context context;
        private readonly ILogger logger;

        public EducationRepository(Project5Context context, ILogger<EducationRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async  Task AddEducationAsync(Education education)
        {
            try
            {
                await context.Educations.AddAsync(education);
                await context.SaveChangesAsync();
                throw new Exception("Error While saving the data i saving the database");
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
            }
        }

        public async Task DeleteEducationAsync(int id)
        {
            try
            {
                var education = await context.Educations.FirstOrDefaultAsync(u=>u.UserId == id);
                if(education == null)
                {
                    throw new Exception("Education is empty filled valid details");
                }
                else
                {
                    context.Educations.Remove(education);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                logger.LogError($"Error log {ex.Message}");
            }
        }

        public Task<IEnumerable<Education>> GetAllEducationsAsync()
        {
            throw new NotImplementedException();
        }

        public async  Task UpdateEducationAsync(Education education,int userid)
        {
            try
            {
                var updateEducation = await context.Educations.FirstOrDefaultAsync(u => u.EducationId == education.EducationId && u.UserId == userid);
                if (updateEducation != null)
                {
                    updateEducation.Degree = education.Degree;
                    updateEducation.Institution = education.Institution;
                    updateEducation.Updated = education.Updated;
                    await context.Educations.AddAsync(updateEducation);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Details Not found");
                }
            }
            catch (Exception ex)
            {

                logger.LogError($"{ex.Message}");
            }
        }
    }
}
