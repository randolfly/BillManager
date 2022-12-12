using BillManager.Models;

namespace BillManager.Services.IServices;

public interface IBillService
{
    Task<List<Bill>> GetBills();
    Task<List<Bill>> GetBillsByPerson(Person person);
    Task<Bill?> GetBillById(int billId);

    Task RemoveBill(int billId);

    Task UpdateBill(Bill bill);
}