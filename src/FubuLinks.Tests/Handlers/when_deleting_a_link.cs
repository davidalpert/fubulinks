using FubuLinks.Repositories;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using FubuLinks.Handlers.Links.Delete;

namespace FubuLinks.Tests.Handlers
{
    [TestFixture]
    public class when_deleting_a_link : InteractionContext<PostHandler>
    {
        [Test]
        public void should_delete_link_and_save()
        {
            var inputModel = new DeleteLinkInputModel
                                 {
                                     ShortenedUrl =
                                         "d046aa6c0d1a4f2f985a33e0bfcfa8e6"
                                 };

            MockFor<ILinkRepository>()
                .Expect(r => r.Delete(inputModel.ShortenedUrl));

            MockFor<ILinkRepository>()
                .Expect(r => r.Save());

            ClassUnderTest
                .Execute(inputModel);

            VerifyCallsFor<ILinkRepository>();
        }
    }
}
