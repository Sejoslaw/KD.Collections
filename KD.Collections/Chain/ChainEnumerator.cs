using System.Collections;
using System.Collections.Generic;

namespace KD.Collections.Chain
{
    public class ChainEnumerator<TEntity> : IEnumerator<TEntity>
    {
        public TEntity Current
        {
            get
            {
                if (this.CurrentCO == null)
                {
                    return default(TEntity);
                }

                return this.CurrentCO.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        private IChainCollection<TEntity> ChainCollection { get; private set; }
        private ChainObject<TEntity> CurrentCO { get; set; }

        public ChainEnumerator(IChainCollection<TEntity> chainCollection)
        {
            this.ChainCollection = chainCollection;

            this.Reset();
        }

        public bool MoveNext()
        {
            if (this.CurrentCO.Next != null)
            {
                this.CurrentCO = this.CurrentCO.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.CurrentCO = this.ChainCollection.Head;
        }

        public void Dispose()
        {
            this.ChainCollection = null;
            this.CurrentCO = null;
        }
    }
}