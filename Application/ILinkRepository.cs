using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface ILinkRepository
    {
        /// <summary>
        /// This method returns the list of all links in the database.
        /// </summary>
        /// <returns></returns>
        Task<List<Link>> List();

        /// <summary>
        /// This method returns a single link from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Link> Details(Guid id);

        /// <summary>
        /// This method creates a link.
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <param name="isPublic"></param>
        /// <returns></returns>
        Task<bool> Create(string fullUrl, bool isPublic);

        /// <summary>
        /// This method allows the update of a link.
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        Task Update(Link link);

        /// <summary>
        /// This method deletes a link from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}
