using Friends.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Friends
{
  public class FriendsContext : DbContext
  {
    public DbSet<User> User { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<Participants> Participants { get; set; }


    public FriendsContext(DbContextOptions<FriendsContext> options) : base(options)
    {

    }
  }
}
