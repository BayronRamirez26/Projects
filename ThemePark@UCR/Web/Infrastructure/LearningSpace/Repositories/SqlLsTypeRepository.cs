using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories
{
    internal class SqlLsTypeRepository : IlearningSpaceTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlLsTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all Learning Space Types from the database.
        /// </summary>
        public async Task<IEnumerable<LSType>> GetLSTypesAsync()
        {
            try
            {
                return await _dbContext.LSTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not retrieve Learning Space Types: {ex.Message}");
                return Enumerable.Empty<LSType>();
            }
        }

        /// <summary>
        /// Adds a new Learning Space Type to the database.
        /// </summary>
        public async Task<bool> PostCreateLSTypeAsync(LSType type)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.LSTypes.AddAsync(type);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating Learning Space Type: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        /// <summary>
        /// Deletes an existing Learning Space Type from the database.
        /// </summary>
        public async Task<bool> PostDeleteLSTypeAsync(Guid typeId)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var type = await _dbContext.LSTypes.FindAsync(typeId);
                if (type == null)
                {
                    return false;
                }

                _dbContext.LSTypes.Remove(type);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Learning Space Type: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        /// <summary>
        /// Updates an existing Learning Space Type in the database.
        /// </summary>
        public async Task<bool> PostUpdateLSTypeAsync(LSType type)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.LSTypes.Update(type);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Learning Space Type: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
