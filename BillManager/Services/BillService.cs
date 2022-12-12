using BillManager.DataContext;
using BillManager.Models;
using BillManager.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BillManager.Services;

public class BillService : IBillService
{
    private readonly AppDataContext dataContext;

    public BillService(AppDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<List<Bill>> GetBills()
    {
        // Todo 注意这里的AsNoTracking，是否可以优化去掉，实现跟踪数据
        return await dataContext.Bills
            .Include(b => b.Assets)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Bill>> GetBillsByPerson(Person person)
    {
        return await dataContext.Bills
            .Include(b => b.Assets)
            .Where(b => b.Person == person)
            .ToListAsync();
    }

    public async Task<Bill?> GetBillById(int billId)
    {
        return await dataContext.Bills
            .Include(b => b.Assets)
            .Where(b => b.Id == billId)
            .FirstOrDefaultAsync();
    }

    public async Task RemoveBill(int billId)
    {
        var bill = await dataContext.Bills
            .Include(b => b.Assets)
            .Where(b => b.Id == billId)
            .FirstOrDefaultAsync();
        if (bill != null)
        {
            dataContext.Bills.Remove(bill);
            await dataContext.SaveChangesAsync();
        }
    }

    public async Task UpdateBill(Bill bill)
    {
        dataContext.Bills.Update(bill);
        await dataContext.SaveChangesAsync();
    }
}