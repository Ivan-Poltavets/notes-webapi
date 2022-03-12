using AutoMapper;
using Notes.Application.Notes.Queries;
using Notes.Persistance;
using Notes.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            var handler = new NoteDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("429f6347-3d70-4d67-9b07-426cb5fbe3ad")
                }, CancellationToken.None);
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("TItle2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
