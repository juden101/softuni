namespace FarmersCreed.Units
{
    using System;
    using System.Text;

    public abstract class Plant : FarmUnit
    {
        private int growTime;

        public Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.ProductionQuantity = productionQuantity;
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return this.GrowTime <= 0; }
        }

        public int GrowTime
        {
            get { return this.growTime; }
            set { this.growTime = value; }
        }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health -= 1;
        }

        public virtual void Grow()
        {
            this.GrowTime -= 1;
        }

        public override string ToString()
        {
            StringBuilder plantInformation = new StringBuilder();

            if (this.IsAlive)
            {
                plantInformation.AppendFormat(", Grown: {0}",
                    this.HasGrown ? "Yes" : "No");

            }

            return base.ToString() + plantInformation.ToString();
        }
    }
}
