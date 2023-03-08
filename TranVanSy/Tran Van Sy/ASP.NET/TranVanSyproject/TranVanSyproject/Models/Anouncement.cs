using Microsoft.AspNetCore.Http;
using System;

namespace JamesTranproject.Models
{
    public class Anouncement
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Introduction { get; set; }
        public string? Img { get; set; }
        public string? DateTimeUse { get; set; }
        public string? ResourceUse { get; set; }

    }
}
