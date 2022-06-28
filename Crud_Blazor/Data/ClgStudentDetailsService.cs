using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Blazor.Data
{
    public class ClgStudentDetailsService
    {
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public ClgStudentDetailsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Student
        public async Task<List<ClgStudentDetails>> GetAllStudentAsync()
        {
            return await _appDBContext.ClgStudentdetails.ToListAsync();
        }
        #endregion

        #region Insert Student
        public async Task<bool> InsertStudentAsync(ClgStudentDetails student)
        {
            await _appDBContext.ClgStudentdetails.AddAsync(student);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Employee by Id
        public async Task<ClgStudentDetails> GetStudentAsync(int Id)
        {
            ClgStudentDetails student = await _appDBContext.ClgStudentdetails.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return student;
        }
        #endregion

        #region Update Student
        public async Task<bool> UpdateStudentAsync(ClgStudentDetails student)
        {
           _appDBContext.ClgStudentdetails.Update(student);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteStudent
        public async Task<bool> DeleteStudentAsync(ClgStudentDetails student)
        {
            _appDBContext.Remove(student);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
