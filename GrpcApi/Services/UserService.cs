using Grpc.Core;
using SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Google.Protobuf.WellKnownTypes;



namespace GrpcApi.Services
{
    public class UserService : GrpcApi.UserService.UserServiceBase
    {
        private readonly ApiDbContext _context;

        public UserService(ApiDbContext context)
        {
            _context = context;
        }

        public override async Task<UserReply> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"User with ID {request.Id} not found"));
            }
            return MapToReply(user);
        }

        public override async Task<UsersReply> GetAllUsers(Empty request, ServerCallContext context)
        {
            var users = await _context.Users.ToListAsync();
            var reply = new UsersReply();
            reply.Users.AddRange(users.Select(MapToReply));
            return reply;
        }

        public override async Task<UserReply> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return MapToReply(user);
        }

        public override async Task<UserReply> UpdateUser(UpdateUserRequest request, ServerCallContext context)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"User with ID {request.Id} not found"));
            }

            user.Name = request.Name;
            user.Email = request.Email;

            await _context.SaveChangesAsync();

            return MapToReply(user);
        }

        public override async Task<Empty> DeleteUser(DeleteUserRequest request, ServerCallContext context)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"User with ID {request.Id} not found"));
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new Empty();
        }

        private static UserReply MapToReply(User user)
        {
            return new UserReply
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = Timestamp.FromDateTime(DateTime.SpecifyKind(user.CreatedAt, DateTimeKind.Utc))
            };
        }
    }
}

