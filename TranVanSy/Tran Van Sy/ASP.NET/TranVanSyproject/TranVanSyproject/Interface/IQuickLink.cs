using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface IQuickLink
    {
        Task<IEnumerable<QuickLink>> GetAll();
        Task<QuickLink> GetItem(int id);
        Task<List<QuickLink>> Add(QuickLink quickLink);
        Task<QuickLink> Update(QuickLink quickLink);
        Task<QuickLink> Delete(int Id);
        Task<string> Upload([FromForm] imgQuickLink obj);
    }
}

