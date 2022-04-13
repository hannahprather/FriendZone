using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;
    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Follow Create(Follow data)
    {
      string sql = @"
        INSERT INTO follows
        (followingId, followersId)
        VALUES
        (@FollowingId, @FollowersId);
        SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    internal List<FollowViewModel> GetProfileFollows(string id)
    {
      string sql = @"
        SELECT 
        f.id AS FollowId,
        a.*
        From follows f
        JOIN accounts a ON a.id = followingId
        WHERE f.followingId = @id;
        ";
      return _db.Query<FollowViewModel>(sql, new { id }).ToList();
    }
  }
}

