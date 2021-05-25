using Application.Common.Interfaces;
using Application.RequestResponseHistories.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RequestResponseHistories.Queries
{
    public class GetRequestResponseHistoriesQuery : IRequest<List<RequestResponseHistoryDto>>
    {
        public class GetRequestResponseHistoriesQueryHandler : IRequestHandler<GetRequestResponseHistoriesQuery, List<RequestResponseHistoryDto>>
        {
            private readonly ITrendyolDbContext _context;
            private readonly IMapper _mapper;
            public GetRequestResponseHistoriesQueryHandler(ITrendyolDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<RequestResponseHistoryDto>> Handle(GetRequestResponseHistoriesQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.RequestResponseHistory
                                            .ToListAsync();
                return _mapper.Map<List<RequestResponseHistoryDto>>(result);
            }
        }
    }
}
