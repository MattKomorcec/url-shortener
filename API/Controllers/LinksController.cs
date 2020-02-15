using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinksController : ControllerBase
    {
        private readonly ILinkRepository _linkRepository;

        public LinksController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<ActionResult<List<Link>>> List()
        {
            return await _linkRepository.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> Details(Guid id)
        {
            var link = await _linkRepository.Details(id);

            if (link == null)
            {
                return NotFound(new { Link = "Not found" });
            }

            return link;
        }

        [HttpPost]
        public async Task<ActionResult> Create(LinkRequest link)
        {
            var result = Uri.TryCreate(link.FullUrl, UriKind.RelativeOrAbsolute, out _);

            if (!result)
            {
                return BadRequest(new { Url = "Please provide a valid URL." });
            }

            var createResult = await _linkRepository.Create(link.FullUrl, link.IsPublic);

            if (createResult)
            {
                return Ok();
            }

            throw new Exception("Something went wrong while creating the link.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _linkRepository.Delete(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest(new { Link = "Link doesn't exist" });
        }
    }
}
