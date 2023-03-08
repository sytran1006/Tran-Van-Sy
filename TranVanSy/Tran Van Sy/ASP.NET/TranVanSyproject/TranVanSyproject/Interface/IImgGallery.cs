using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface IImgGallery
    {
        Task<IEnumerable<ImageGallery>> GetAll();
        Task<ImageGallery> GetItem(int id);
        Task<List<ImageGallery>> Add(ImageGallery imageGallery);
        Task<ImageGallery> Update(ImageGallery imageGallery);
        Task<ImageGallery> Delete(int Id);
        Task<string> Upload([FromForm] imgImg obj);
    }
}
