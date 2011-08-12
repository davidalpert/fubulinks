using System;
using FubuLinks.Repositories;
using FubuValidation;
using FubuLinks.Handlers.Links.Create;

namespace FubuLinks.Handlers.Links.Delete // links/create (POST)
{
    public class PostHandler
    {
        private readonly ILinkRepository _repository;
        private readonly IUrlShortener _urlShortener;

        public PostHandler(ILinkRepository repository, IUrlShortener urlShortener)
        {
            _repository = repository;
            _urlShortener = urlShortener;
        }

        public JsonResponse Execute(DeleteLinkInputModel inputModel)
        {
            _repository.Delete(inputModel.ShortenedUrl);
            _repository.Save();

            return new JsonDeleteLinkResponse
            {
                Success = true,
                ShortenedUrl = inputModel.ShortenedUrl
            };
        }
    }

    public class DeleteLinkInputModel
    {
        [Required]
        public string ShortenedUrl { get; set; }
    }

    public class JsonDeleteLinkResponse : JsonResponse
    {
        public string ShortenedUrl { get; set; }
    }
}