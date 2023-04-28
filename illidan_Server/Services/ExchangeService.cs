using AutoMapper;
using illidan_Shared;

namespace illidan_Server.Services
{
    class ExchangeServiceImplementation : QueueService.QueueServiceBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public ExchangeServiceImplementation(DataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper=mapper;
        }

    }
}