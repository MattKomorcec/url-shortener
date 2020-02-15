using Application.Helpers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class LinkRepository : ILinkRepository
    {
        private readonly DataContext _context;

        public LinkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Link>> List()
        {
            return await _context.Links
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Link> Details(Guid id)
        {
            return await _context.Links
                .SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> Create(string fullUrl, bool isPublic)
        {
            var link = new Link
            {
                FullUrl = fullUrl,
                IsPublic = isPublic,
                ShortUrl = $"/{ShortUrlGenerator.GenerateRandomShortUrl()}",
                Id = Guid.NewGuid()
            };

            _context.Links.Add(link);

            var result = await _context.SaveChangesAsync() > 0;

            return result;
        }

        public Task Update(Link link)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            var link = await Details(id);

            if (link != null)
            {
                _context.Remove(link);
                return await _context.SaveChangesAsync() > 0;
            }

            return await Task.FromResult(false);
        }
    }
}
