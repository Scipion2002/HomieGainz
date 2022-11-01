using HomieGainz.Api.Friendships.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomieGainz.Api.Friendships.Controllers
{
    [ApiController]
    [Route("Friendships")]
    public class FriendshipsController : ControllerBase
    {
        private readonly IFriendshipService friendshipService;

        public FriendshipsController(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        [HttpGet("/sendFriendRequest/{fromUserId}/{toUserId}")]
        public async Task<IActionResult> SendFriendRequestAsync(int fromUserId, int toUserId)
        {
            var result = await friendshipService.SendFriendRequestAsync(fromUserId, toUserId);
            if (result.IsSuccess)
            {
                return Ok(result.Friendship);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("/acceptRequest/{toUserId}/{fromUserId}")]
        public async Task<IActionResult> AcceptFriendRequestAsync(int toUserId, int fromUserId)
        {
            var result = await friendshipService.AcceptFriendRequestAsync(toUserId, fromUserId);
            if (result.IsSuccess)
            {
                return Ok(result.Friendship);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("/rejectRequest/{toUserId}/{fromUserId}")]
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
