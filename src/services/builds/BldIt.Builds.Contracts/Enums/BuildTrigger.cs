namespace BldIt.Builds.Contracts.Enums;

public enum BuildTrigger
{
    Manual,
    GitHubHook,
    Periodically,
    AfterOtherJob,
    FromScripts
}