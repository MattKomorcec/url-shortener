using System;

namespace Domain
{
    public class Link
    {
        public Guid Id { get; set; }
        public string ShortUrl { get; set; }
        public string FullUrl { get; set; }
        public bool IsPublic { get; set; }
    }
}
