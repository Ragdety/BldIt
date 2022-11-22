namespace BldIt.Api.Shared.Services.Errors;

public static class ErrorTypeMessages
{
    public const string ExistingInstance = "Instance already exists";
    public const string InvalidInstance  = "Invalid instance";
    public const string InstanceNotFound = "Instance was not found";
    public const string InstanceNotOwned = "Instance does not belong to current user";
    
    //Auth
    public const string InvalidCredentials = "Invalid credentials";
}