using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        protected const string ProductIdSuffix = "Product";

        private int health;
        private int productionQuantity;

        public FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public int ProductionQuantity
        {
            get { return this.productionQuantity; }
            set { this.productionQuantity = value; }
        }

        public bool IsAlive
        {
            get { return this.health > 0; }
        }

        public abstract Product GetProduct();

        protected virtual void Die()
        {
            this.Health = 0;
        }

        public override string ToString()
        {
            return base.ToString() +
                (this.IsAlive ? String.Format(", Health: {0}", this.Health) : ", DEAD");
        }
    }
}
