using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using HbSystem.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HbSystemContext _context;

        public Repository(HbSystemContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientDiagnosis>> GetByTcAsync(string tcNumber)
        {
            return await _context.Set<PatientDiagnosis>()
                .Include(pd => pd.Referral)
                .Include(pd => pd.Diagnosis)
                .Include(pd => pd.Referral.Patient)
                .Include(pd => pd.Referral.Department)
                .Include(pd => pd.Referral.Doctor)
                .Where(pd => pd.Referral.Patient.TcNumber == tcNumber).ToListAsync();
        }
    }

}
