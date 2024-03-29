using AutoMapper;
using Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Server.Services
{
    public class QueueServiceImplementation : QueueService.QueueServiceBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public QueueServiceImplementation(DataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper=mapper;
        }

        [Authorize]public override Task<CreateQueueReply> CreateQueue(CreateQueueRequest request, ServerCallContext context)
        {
            // Get user id from jwt token
            int id = int.Parse(context.GetHttpContext().User.FindFirst("Id").Value);
            var queue = new Models.Queue(id, request.Name, request.ImageLink);
            _db.Queues.Add(queue);
            _db.SaveChanges();
            return Task.FromResult<CreateQueueReply>(new CreateQueueReply() { QueueId = queue.Id });
        }
        [Authorize]public override Task<GetQueuesReply> GetQueues(Shared.Empty request, ServerCallContext context)
        {
            var queues = _db.Queues.Select(x => _mapper.Map<Server.Models.Queue, Shared.Queue>(x));
            var reply = new GetQueuesReply();
            reply.Queues.AddRange(queues);
            return Task.FromResult(reply);
        }
        [Authorize]public override Task<GetQueueTokensReply> GetQueueTokens(GetQueueTokensRequest request, ServerCallContext context)
        {
            var tokens = _db.QueueTokens.Where(x => x.QueueId == request.QueueId);
            var reply = new GetQueueTokensReply();
            foreach (var token in tokens)
            {
                reply.Tokens.Add(_mapper.Map<Server.Models.QueueToken, Shared.QueueToken>(token));
            }
            return Task.FromResult(reply);
        }
        [Authorize]public override Task<StandartReply> Enqueue(EnqueueRequest request, ServerCallContext context)
        {
            // Get user id from jwt token
            int userId = int.Parse(context.GetHttpContext().User.FindFirst("Id").Value);
            // Get queue id from request
            var queue = _db.Queues.FirstOrDefault(x => x.Id == request.QueueId);
            if (queue == null)
            {
                return Task.FromResult<StandartReply>(new StandartReply() { Success = false, Message = "Queue not found" });
            }
            // Check if user is already in the queue
            if (_db.QueueTokens.FirstOrDefault(x => x.OwnerId == userId && x.QueueId == request.QueueId) != null)
            {
                return Task.FromResult<StandartReply>(new StandartReply() { Message = "You are already in the queue" });
            }
            // Add user to the queue
            _db.QueueTokens.Add(new Server.Models.QueueToken(userId, request.QueueId, ++queue.LastAnimal, ++queue.LastColor));
            _db.SaveChanges();
            return Task.FromResult<StandartReply>(new StandartReply() { Success = true, Message = "You have been added to the queue" });
        }
        [Authorize]public override Task<StandartReply> Dequeue(DequeueRequest request, ServerCallContext context)
        {
            // Get user id from jwt token
            int userId = int.Parse(context.GetHttpContext().User.FindFirst("Id").Value);
            // Get queue id from request
            var queue = _db.Queues.FirstOrDefault(x => x.Id == request.QueueId);
            if (queue == null)
            {
                return Task.FromResult<StandartReply>(new StandartReply() { Success = false, Message = "Queue not found" });
            }
            // Check if user is in the queue
            var queueToken = _db.QueueTokens.FirstOrDefault(x => x.OwnerId == userId && x.QueueId == request.QueueId);
            if (queueToken == null)
            {
                return Task.FromResult<StandartReply>(new StandartReply() { Success = false, Message = "You are not in the queue" });
            }
            // Remove user from the queue
            _db.QueueTokens.Remove(queueToken);
            _db.SaveChanges();
            return Task.FromResult<StandartReply>(new StandartReply() { Success = true, Message = "You have been removed from the queue" });
        }
    }
}