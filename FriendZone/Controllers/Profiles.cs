using System;
using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly FollowsService _fs;
    private readonly AccountService _acs;

    public ProfilesController(FollowsService fs, AccountService acs)
    {
      _fs = fs;
      _acs = acs;
    }

    [HttpGet("{id}/followers")]
    public ActionResult<List<FollowViewModel>> GetProfileFollows(string id)
    {
      try
      {
        List<FollowViewModel> follows = _fs.GetProfileFollows(id);
        return Ok(follows);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }

}