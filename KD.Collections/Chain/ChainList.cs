using System.Collections.Generic;

namespace KD.Collections.Chain
{
    /// <summary>
    /// Implementation based on concept of List using chain-algorithms.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ChainList<TEntity> : ChainCollection<TEntity>, IChainCollection<TEntity>, IList<TEntity>
    {
        public TEntity this[int index]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override void Add(TEntity item)
        {
            ChainObject<TEntity> toAdd = null;

            if (this.Head == null)
            {
                toAdd = this.Head;
            }
            else
            {
                var last = this.GetLast();
                toAdd = last.Next;
            }

            toAdd = new ChainObject<TEntity>
            {
                Value = item
            };
        }

        public override bool Contains(TEntity item)
        {
            if (this.Head == null)
            {
                return false;
            }

            bool contains = false;

            this.ForEach((entity, index) =>
            {
                if (entity.Value.Equals(item))
                {
                    contains = true;
                }
            });

            return contains;
        }

        public override void CopyTo(TEntity[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public int IndexOf(TEntity item)
        {
            if (this.Head == null)
            {
                return -1;
            }

            bool found = false;
            int foundIndex = -1;

            this.ForEach((entity, index) =>
            {
                if (!found)
                {
                    if (entity.Value.Equals(item))
                    {
                        found = true;
                        foundIndex = index;
                    }
                }
            });

            if (!found)
            {
                return -1;
            }

            return foundIndex;
        }

        public void Insert(int index, TEntity item)
        {
            throw new System.NotImplementedException();
        }

        public override bool Remove(TEntity item)
        {
            if (this.Head == null)
            {
                return true;
            }

            if (this.Head.Value.Equals(item))
            {
                this.Head = null;
                return true;
            }

            bool removed = false;

            this.ForEach((entity, index) =>
            {
                if (entity.Next.Value.Equals(item))
                {
                    entity.Next = entity.Next.Next;
                    removed = true;
                }
            });

            return removed;
        }

        public void RemoveAt(int index)
        {
            if (this.Head == null)
            {
                return;
            }

            if (index == 0)
            {
                this.Head = this.Head.Next;
            }

            this.ForEach((entity, entityIndex) =>
            {
                if (entityIndex + 1 == index)
                {
                    entity.Next = entity.Next?.Next;
                }
            });
        }
    }
}