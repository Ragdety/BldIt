namespace BldIt.Email.Contracts.Contracts;

public record EmailSend(Guid userID, string message, string sendTo, string userName);