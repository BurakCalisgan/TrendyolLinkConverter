using Application.Common.Interfaces;
using Application.RequestResponseHistories.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RequestResponseHistories.Commands
{
    public class CreateRequestResponseHistoryCommand : IRequest
    {
        public RequestResponseHistoryDto RequestResponseHistory { get; set; }
        public class CreateRequestResponseHistoryCommandHandler : IRequestHandler<CreateRequestResponseHistoryCommand>
        {
            private readonly ITrendyolDbContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            public CreateRequestResponseHistoryCommandHandler(ITrendyolDbContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(CreateRequestResponseHistoryCommand request, CancellationToken cancellationToken)
            {
                var requestResponseHistory = _mapper.Map<RequestResponseHistory>(request.RequestResponseHistory);
                requestResponseHistory.Guid = System.Guid.NewGuid();
                _context.RequestResponseHistory.Add(requestResponseHistory);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
