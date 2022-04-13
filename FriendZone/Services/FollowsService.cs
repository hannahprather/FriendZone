using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository _fr;
    public FollowsService(FollowsRepository fr)
    {
      _fr = fr;
    }
    internal Follow Create(Follow followerData)
    {
      // Follow exists = _fr.Get(followerData.AccountId, followerData.AccountId);
      // if (exists != null)
      // {
      //   return exists;
      // }
      return _fr.Create(followerData);

    }

    internal List<FollowViewModel> GetProfileFollows(string id)
    {
      return _fr.GetProfileFollows(id);
    }
  }
}