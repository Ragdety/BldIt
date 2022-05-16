using System;
using System.Security.Claims;
using BldIt.Models.Enums;

namespace BldIt.Api
{
    public struct BldItConstraints
    {
        public struct Policies
        {
            // public const string Anon = nameof(Anon);
            // public const string User = IdentityServerConstants.LocalApi.PolicyName;
            public const string Mod = nameof(Mod);
            public const string Admin = nameof(Admin);
        }

        public struct IdentityResources
        {
            public const string RoleScope = "role";
        }

        public struct Claims
        {
            public const string Role = "role";
            public static readonly Claim ModeratorClaim = new(Role, Roles.Mod);
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

            public const string TempPrefix = "bldit_temp_";

            public static string GenerateBuildStepFileType(BuildStepType buildStepType)
            {
                return buildStepType switch
                {
                    BuildStepType.Batch => ".bat",
                    BuildStepType.Shell => ".sh",
                    _ => throw new ArgumentOutOfRangeException(
                        nameof(buildStepType),
                        buildStepType, 
                        "Build Step Type not supported")
                };
            }
        }
    }
}