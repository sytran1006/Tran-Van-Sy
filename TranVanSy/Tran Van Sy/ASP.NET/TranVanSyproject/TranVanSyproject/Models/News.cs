using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace JamesTranproject.Models
{
    public class News
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Introduction { get; set; }
        public string? Img { get; set; }
        public string? DateTimeUse { get; set; }

    }
}
