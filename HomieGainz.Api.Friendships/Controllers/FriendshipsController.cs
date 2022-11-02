using HomieGainz.Api.Friendships.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomieGainz.Api.Friendships.Controllers
{
    [ApiController]
    [Route("/friendships/")]
    public class FriendshipsController : ControllerBase
    {
        private readonly IFriendshipService friendshipService;

        public FriendshipsController(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        [Authorize]
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAllRequestsFromUser(int UserId)
        {
            var result = await friendshipService.GetAllFriendshipRequestsFromUser(UserId);
            if (result.IsSuccess)
            {
                return Ok(result.Friendships);
            }
            return BadRequest(result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("sendFriendRequest/{fromUserId}/{toUserId}")]
        public async Task<IActionResult> SendFriendRequestAsync(int fromUserId, int toUserId)
        {
            var result = await friendshipService.SendFriendRequestAsync(fromUserId, toUserId);
            if (result.IsSuccess)
            {
                return Ok(result.Friendship);
            }
            return BadRequest(result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("acceptRequest/{toUserId}/{fromUserId}")]
        public async Task<IActionResult> AcceptFriendRequestAsync(int toUserId, int fromUserId)
        {
            var result = await friendshipService.AcceptFriendRequestAsync(toUserId, fromUserId);
            if (result.IsSuccess)
            {
                return Ok(result.Friendship);
            }
            return BadRequest(result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("rejectRequest/{toUserId}/{fromUserId}")]
        public async Task<IActionResult> RejectFriendRequestAsync(int toUserId, int fromUserId)
        {
            var result = await friendshipService.RejectFriendRequestAsync(toUserId, fromUserId);
            if (result.IsSuccess)
            {
                return Ok(result.Friendship);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
