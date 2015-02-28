namespace FarmersCreed.Units
{
    using System;

    public class TobaccoPlant : Plant
    {
        private const int TobaccoPlantBaseHealth = 12;
        private const int TobaccoPlantBaseGrowTime = 4;
        private const int TobaccoPlantProductQuantity = 10;

        public TobaccoPlant(string id)
            : base(id, TobaccoPlantBaseHealth, TobaccoPlantProductQuantity, TobaccoPlantBaseGrowTime)
        {
        }

        public override void Grow()
        {
            for (int i = 0; i < 2; i++)
            {
                base.Grow();
            }
        }

        public override Product GetProduct()
        {
            if(!this.HasGrown)
            {
                throw new InvalidOperationException("You cannot exploit dead tobacco plants!");
            }

            if(!this.IsAlive)
            {
                throw new InvalidOperationException("Tobacco cannot be epxloited while growing!");
            }

            return new Product(this.Id + ProductIdSuffix, ProductType.Tobacco, TobaccoPlantProductQuantity);
        }
    }
}
