using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAll1();
        Task<News> GetItem(int id);
        Task<List<News>> Add(News anew);
        Task<News> Update(News anew);
        Task<News> Delete(int id);
        Task<string> Upload([FromForm] imgNew obj);
    }
}
