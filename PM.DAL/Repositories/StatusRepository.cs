using Microsoft.EntityFrameworkCore;
using PM.DAL.Data;
using PM.DAL.Repositories.Interfaces;
using PM.Models.Entities;

namespace PM.DAL.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly ProjectManagementContext _context;

    public StatusRepository(ProjectManagementContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Status>> GetAllAsync()
    {
        return await _context.Statuses.ToListAsync();
    }

    public async Task<Status?> GetByIdAsync(int id)
    {
        return await _context.Statuses.FindAsync(id);
    }

    public async Task<Status> AddAsync(Status status)
    {
        _context.Statuses.Add(status);
        await _context.SaveChangesAsync();
        return status;
    }

    public async Task UpdateAsync(Status status)
    {
        _context.Statuses.Update(status);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var status = await _context.Statuses.FindAsync(id);
        if (status is not null)
        {
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
        }
    }
}
