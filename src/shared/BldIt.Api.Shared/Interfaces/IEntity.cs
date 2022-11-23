namespace BldIt.Api.Shared.Interfaces;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
    bool Deleted { get; set; }
    DateTime CreatedAt { get; set; }
}