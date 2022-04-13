using System.Threading.Tasks;
using FriendZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FriendZone.Models;
using CodeWorks.Auth0Provider;
using System;

namespace FriendZone.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class FollowsController : ControllerBase
  {
    private readonly FollowsService _fs;
    public FollowsController(FollowsService fs)
    {
      _fs = fs;
    }


    //creates a followerId = userInfo//
    [HttpPost]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followerData)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        followerData.FollowersId = user.Id;
        Follow created = _fs.Create(followerData);
        return Ok(created);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}