using AspNetCore.Identity.MongoDbCore.Models;
using BldIt.Api.Shared;
using MongoDbGenericRepository.Attributes;

namespace BldIt.Identity.Core.Models;

[CollectionName(BldItApiConstants.Services.Identity.Collections.Users)]
public class User : MongoIdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.Now;
}