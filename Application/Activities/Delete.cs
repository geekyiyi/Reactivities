using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                // get the activity with the given id
                var activity = await _context.Activities.FindAsync(request.Id);
                
                _context.Remove(activity);
                await _context.SaveChangesAsync();
                //will basically return nothing
                return Unit.Value;

            }
        }
    }
}