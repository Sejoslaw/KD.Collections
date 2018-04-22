using System;
using System.Collections;
using System.Collections.Generic;

namespace KD.Collections.Chain
{
    /// <summary>
    /// Describes general Collection which use chain-algorithm.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ChainCollection<TEntity> : IChainCollection<TEntity>
    {
        /// <summary>
        /// Head of chain collection.
        /// </summary>
        public ChainObject<TEntity> Head { get; internal set; }

        public virtual int Count
        {
            get
            {
                int count = 0;
                this.GetLast((entity) => count++);
                return count;
            }
        }

        public virtual bool IsReadOnly { get; private set; }

        public ChainCollection() : this(false)
        {
        }

        public ChainCollection(bool isReadOnly)
        {
            this.IsReadOnly = isReadOnly;
        }

        public virtual void Clear()
        {
            this.Head = null;
        }

        public virtual IEnumerator<TEntity> GetEnumerator()
        {
            return new ChainEnumerator<TEntity>(this);
        }

        public abstract void Add(TEntity item);
        public abstract bool Contains(TEntity item);
        public abstract void CopyTo(TEntity[] array, int arrayIndex);
        public abstract bool Remove(TEntity item);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected ChainObject<TEntity> GetLast(Action<ChainObject<TEntity>> forEach = null)
        {
            ChainObject<TEntity> last = null;
            this.ForEach((entity, index) => last = entity);
            return last;
        }

        protected void ForEach(Action<ChainObject<TEntity>, int> forEach, Func<ChainObject<TEntity>, int, bool> checkBreak = null)
        {
            if (this.Head == null)
            {
                return;
            }

            ChainObject<TEntity> last = this.Head;
            int index = 0;

            while (last != null)
            {
                forEach?.Invoke(last, index);

                if (checkBreak != null &&
                checkBreak.Invoke(last, index))
                {
                    return;
                }

                if (last.Next == null)
                {
                    break;
                }

                last = last.Next;
                index++;
            }
        }
    }
}