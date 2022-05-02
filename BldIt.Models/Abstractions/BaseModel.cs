using System;

namespace BldIt.Models.Abstractions
{
    public abstract class BaseModel<TKey>
    {
        public TKey Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}