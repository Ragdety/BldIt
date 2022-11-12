using AspNetCore.Identity.MongoDbCore.Models;
using BldIt.Api.Shared;
using MongoDbGenericRepository.Attributes;

namespace BldIt.Identity.Core.Models;

[CollectionName(BldItApiConstants.Services.Identity.Collections.Roles)]
public class Role : MongoIdentityRole<Guid>
{
    
}