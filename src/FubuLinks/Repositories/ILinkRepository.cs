using System.Collections.Generic;
using System.Linq;
using Raven.Client;

namespace FubuLinks.Repositories
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetAll();
        void Insert(Link link);
        void Save();
        void Delete(string shortenedUrl);
    }

    public class LinkRepository : ILinkRepository
    {
        private readonly IDocumentSession _session;

        public LinkRepository(IDocumentSession session)
        {
            _session = session;
        }

        public IEnumerable<Link> GetAll()
        {
            return _session.Query<Link>();
        }

        public void Insert(Link link)
        {
            _session.Store(link);
        }

        public void Save()
        {
            _session.SaveChanges();
        }

        public void Delete(string shortenedUrl)
        {
            var link = _session.Query<Link>().Where(l => l.ShortenedUrl == shortenedUrl).FirstOrDefault();

            if (link == null)
                return;

            _session.Delete(link);
        }
    }
}