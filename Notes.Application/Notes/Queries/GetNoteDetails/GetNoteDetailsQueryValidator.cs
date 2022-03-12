using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(getNoteDetails => getNoteDetails.Id).NotEqual(Guid.Empty);
            RuleFor(getNoteDetails => getNoteDetails.UserId).NotEqual(Guid.Empty);
        }
    }
}
