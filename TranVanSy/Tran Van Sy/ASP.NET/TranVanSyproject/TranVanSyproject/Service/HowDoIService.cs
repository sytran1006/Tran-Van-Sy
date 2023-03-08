using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JamesTranproject.Service
{
    public class HowDoIService : IHowDoI
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public HowDoIService(ReactContext reactContext, IWebHostEnvironment webHostEnvironment)
        {
            this._context = reactContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<HowDoI>> Add(HowDoI howDoI)
        {
            _context.HowDoIs.Add(howDoI);
            await _context.SaveChangesAsync();
            return (await _context.HowDoIs.ToListAsync());

        }

        public async Task<HowDoI> Delete(int id)
        {
            var result = await _context.HowDoIs.FindAsync(id);
            if (result == null)
                return null;

            _context.HowDoIs.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<HowDoI> GetItem(int Id)
        {
            return await _context.HowDoIs
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<HowDoI>> GetAll()
        {
            return await _context.HowDoIs.ToListAsync();
        }

        public async Task<HowDoI> Update(HowDoI howDoI)
        {
            var result = await _context.HowDoIs
                .FirstOrDefaultAsync(n => n.Id == howDoI.Id);

            if (result != null)
            {
                result.IconQuestion = howDoI.IconQuestion;
                result.IconAnswer = howDoI.IconAnswer;
                result.Question = howDoI.Question;
                result.Answer = howDoI.Answer;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<string> Upload([FromForm] imgHowDoI obj)
        {
            if (obj.imageHowDoI.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment + "\\Images\\" + obj.imageHowDoI.FileName))
                    {
                        obj.imageHowDoI.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Images." + obj.imageHowDoI.FileName;
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
