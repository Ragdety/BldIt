using System.Security.Claims;

namespace BldIt.Api.Shared
{
    public struct BldItApiConstraints
    {
        public struct Policies
        {
            // public const string User = IdentityServerConstants.LocalApi.PolicyName;
            public const string Admin = nameof(Admin);
        }

        public struct IdentityResources
        {
            public const string RoleScope = "role";
        }

        public struct Claims
        {
            public const string Role = "role";
            public static readonly Claim AdminClaim = new(Role, Roles.Admin);
        }

        public struct Roles
        {
            public const string Mod = nameof(Mod);
            public const string Admin = nameof(Admin);
        }

        public struct Files
        {
            public struct Providers
            {
                public const string Local = nameof(Local);
                public const string S3 = nameof(S3);
            }
            
            public const string BldItTempFolderName = "temp";

            public const string BldItTempPrefix = "bldit_temp_";
        }
    }
}