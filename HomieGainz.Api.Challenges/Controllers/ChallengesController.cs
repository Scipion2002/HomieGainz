using HomieGainz.Api.Challenges.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomieGainz.Api.Challenges.Controllers
{
    [ApiController]
    [Route("/challenges/")]
    public class ChallengesController : ControllerBase
    {
        private readonly IChallengeService challengeService;

        public ChallengesController(IChallengeService challengeService)
        {
            this.challengeService = challengeService;
        }

        [Authorize]
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAllRequestsFromUser(int UserId)
        {
            var result = await challengeService.GetAllChallengeRequestsFromUser(UserId);
            if (result.IsSuccess)
            {
                return Ok(result.Challenges);
            }
            return BadRequest(result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("sendChallengeRequest/{fromUserId}/{toUserId}/{workoutId}")]
        public async Task<IActionResult> SendFriendRequestAsync(int fromUserId, int toUserId, int workoutId)
        {
            var result = await challengeService.SendChallengeRequestAsync(fromUserId, toUserId, workoutId);
            if (result.IsSuccess)
            {
                return Ok(result.Challenge);
            }
            return BadRequest(result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("acceptRequest/{toUserId}/{fromUserId}/{workoutId}")]
        public async Task<IActionResult> AcceptFriendRequestAsync(int toUserId, int fromUserId, int workoutId)
        {
            var result = await challengeService.AcceptChallengeRequestAsync(toUserId, fromUserId, workoutId);
            if (result.IsSuccess)
            {
                return Ok(result.Challenge);
            }
            return BadRequest(result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("rejectRequest/{toUserId}/{fromUserId}/{workoutId}")]
        public async Task<IActionResult> RejectFriendRequestAsync(int toUserId, int fromUserId, int workoutId)
        {
            var result = await challengeService.RejectChallengeRequestAsync(toUserId, fromUserId, workoutId);
            if (result.IsSuccess)
            {
                return Ok(result.Challenge);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
