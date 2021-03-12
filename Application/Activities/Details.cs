using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        // fetching data instead of updating anything
        public class Query : IRequest<Activity>
        {
            // specify the type of Id
            public Guid Id { get; set; }
        }

        // create class for the handler--handle the request
        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                // request is the query we created above, which has a property Id
                return await _context.Activities.FindAsync(request.Id);
            }
        }
    }
}