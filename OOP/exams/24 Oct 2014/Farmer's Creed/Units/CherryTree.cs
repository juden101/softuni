namespace FarmersCreed.Units
{
    using System;

    class CherryTree : FoodPlant
    {
        private const int baseHealth = 14;
        private const int baseProductQuantity = 4;
        private const int baseGrowTime = 3;
        private const int baseProductHealthEffect = 2;

        public CherryTree(string id)
            : base(id, baseHealth, baseProductQuantity, baseGrowTime, baseProductHealthEffect)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("You cannot exploit dead cherry.");
            }

            return new Food(this.Id + ProductIdSuffix, ProductType.Cherry, FoodType.Organic, baseProductQuantity, baseProductHealthEffect);
        }
    }
}
