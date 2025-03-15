using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class DeleteActivity
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(DataContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            Activity activity = await context.Activities
                .FindAsync([request.Id], cancellationToken)
                    ?? throw new Exception("Cannot find activity");
            
            context.Remove(activity);

            await context.SaveChangesAsync();
        }
    }

}
