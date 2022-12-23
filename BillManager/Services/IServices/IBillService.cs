using BillManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillManager.Services.IServices;

public interface IBillService
{
    Task<int> GetBillMaxId();
    Task<List<Bill>> GetBills();
    Task<List<Bill>> GetBillsByPerson(Person person);
    Task<Bill?> GetBillById(int billId);

    Task AddBill(Bill bill);

    Task RemoveBill(int billId);

    Task UpdateBill(Bill bill);

    Task<FileStreamResult> ExportBills(List<Bill> bills);
}