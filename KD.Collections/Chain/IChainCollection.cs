using System.Collections.Generic;

namespace KD.Collections.Chain
{
    /// <summary>
    /// Describes <see cref="ICollection{T}"/> which is using chaining-algorithms.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IChainCollection<TEntity> : ICollection<TEntity>
    {
        /// <summary>
        /// Head of chain collection.
        /// </summary>
        ChainObject<TEntity> Head { get; }
    }
}