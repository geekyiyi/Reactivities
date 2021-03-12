using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // not directly add activity to the database at this code
                // just add a new activity in the memory
                _context.Activities.Add(request.Activity);
                // async the changes
                await _context.SaveChangesAsync();
                // will return nothing, just a way letting API controller know that all things are finished
                return Unit.Value;

            }
        }
    }
}