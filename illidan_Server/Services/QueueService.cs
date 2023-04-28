using AutoMapper;
using illidan_Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace illidan_Server.Services
{
    class QueueServiceImplementation : QueueService.QueueServiceBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public QueueServiceImplementation(DataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper=mapper;
        }
        
    }
}