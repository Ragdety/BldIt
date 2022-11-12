namespace BldIt.Api.Shared.Interfaces;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}