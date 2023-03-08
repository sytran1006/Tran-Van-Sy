using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;

namespace JamesTranproject.Service
{
    public class NewService : INewsService
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public NewService(ReactContext reactContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = reactContext;
            _webHostEnvironment= webHostEnvironment;
        }

        public async Task<List<News>> Add(News anew)
        {
            _context.News.Add(anew);
            await _context.SaveChangesAsync();
            return (await _context.News.ToListAsync());

        }

        public async Task<News> Delete(int id)
        {
            var result = await _context.News.FindAsync(id);
            if (result == null)
                return null;

            _context.News.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<News> GetItem(int Id)
        {
            return await _context.News
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<News>> GetAll1()
        {
            return await  _context.News.ToListAsync();
        }

        public async Task<News> Update(News anew)
        {
            var result = await _context.News
                .FirstOrDefaultAsync(n => n.Id == anew.Id);

            if (result != null)
            {
                result.Title = anew.Title;
                result.Introduction = anew.Introduction;
                result.Img = anew.Img;
                result.DateTimeUse = anew.DateTimeUse;


                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<string> Upload([FromForm] imgNew obj)
        {
            if (obj.imageNew.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment + "\\Images\\");
                    }
                    using(FileStream fileStream= System.IO.File.Create(_webHostEnvironment+ "\\Images\\" + obj.imageNew.FileName))
                    {
                        obj.imageNew.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Images." + obj.imageNew.FileName;
                    }
                }
                catch(Exception e)
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
