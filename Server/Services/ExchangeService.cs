using AutoMapper;
using Grpc.Core;
using Shared;
using Microsoft.AspNetCore.Authorization;

namespace Server.Services
{
    public class ExchangeServiceImplementation : ExchangeService.ExchangeServiceBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        public ExchangeServiceImplementation(DataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper=mapper;
        }
        
        [Authorize] public override Task<GetBidsReply> GetBids(Empty request, ServerCallContext context)
        {
            return base.GetBids(request, context);
        }
        [Authorize] public override Task<StandartReply> CreateBid(CreateBidRequest request, ServerCallContext context)
        {
            return base.CreateBid(request, context);
        }
        [Authorize] public override Task<StandartReply> Exchange(ExchangeRequest request, ServerCallContext context)
        {
            return base.Exchange(request, context);
        }
        [Authorize] public override Task<GetBidReply> GetBid(GetBidRequest request, ServerCallContext context)
        {
            return base.GetBid(request, context);
        }
    }
}