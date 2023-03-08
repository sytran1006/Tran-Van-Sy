using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace JamesTranproject.Service
{
    public class ImgGalleryService : IImgGallery
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public ImgGalleryService(ReactContext reactContext, IWebHostEnvironment webHostEnvironment)
        {
            this._context = reactContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<ImageGallery>> Add(ImageGallery imageGallery)
        {
            _context.ImageGallerys.Add(imageGallery);
            await _context.SaveChangesAsync();
            return (await _context.ImageGallerys.ToListAsync());

        }

        public async Task<ImageGallery> Delete(int id)
        {
            var result = await _context.ImageGallerys.FindAsync(id);
            if (result == null)
                return null;

            _context.ImageGallerys.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<ImageGallery> GetItem(int Id)
        {
            return await _context.ImageGallerys
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<ImageGallery>> GetAll()
        {
            return await _context.ImageGallerys.ToListAsync();
        }

        public async Task<ImageGallery> Update(ImageGallery imageGallery)
        {
            var result = await _context.ImageGallerys
                .FirstOrDefaultAsync(n => n.Id == imageGallery.Id);

            if (result != null)
            {
                result.Img = imageGallery.Img;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<string> Upload([FromForm] imgImg obj)
        {
            if (obj.imageImg.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment + "\\Images\\" + obj.imageImg.FileName))
                    {
                        obj.imageImg.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Images." + obj.imageImg.FileName;
                    }
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else
            {
                return "false";
            }
        }
    }
}
