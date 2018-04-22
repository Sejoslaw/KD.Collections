namespace KD.Collections.Chain
{
    /// <summary>
    /// Defines single object inside chain in <see cref="IChainCollection{TEntity}"/>.
    /// </summary>
    public sealed class ChainObject<TValue>
    {
        /// <summary>
        /// Value of current object.
        /// </summary>
        public TValue Value { get; set; }
        /// <summary>
        /// Next object in chain, connected to this object.
        /// </summary>
        public ChainObject<TValue> Next { get; set; }
    }
}