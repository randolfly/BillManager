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

    public async Task<int> GetBillMaxId()
    {
        return await dataContext.Bills.MaxAsync(b => b.Id);
    }

    public async Task<List<Bill>> GetBills()
    {
        return await dataContext.Bills
            .Include(b => b.Assets)
            // .AsNoTracking()
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

    public async Task AddBill(Bill bill)
    {
        await dataContext.Bills.AddAsync(bill);
        await dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// remove bill with (<see cref="int"/>) Id
    /// </summary>
    /// <param name="billId"></param>
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
        var oldItem = await GetBillById(bill.Id);
        if (oldItem != null)
        {
            oldItem.Detail = bill.Detail;
            oldItem.Assets = bill.Assets;
            oldItem.Person = bill.Person;
            oldItem.Brief = bill.Brief;
            oldItem.Price = bill.Price;
            oldItem.BillState = bill.BillState;
            oldItem.DateTime = bill.DateTime;
            oldItem.RbsType = bill.RbsType;

            dataContext.Bills.Update(oldItem);
            await dataContext.SaveChangesAsync();
        }
    }
}