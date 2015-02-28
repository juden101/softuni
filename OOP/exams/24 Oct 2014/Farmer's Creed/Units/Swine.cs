namespace FarmersCreed.Units
{
    using System;

    class Swine : Animal
    {
        private const int SwineBaseHealth = 20;
        private const int SwineProductHealthEffect = 5;
        private const int SwineProductQuantity = 1;

        public Swine(string id)
            : base(id, SwineBaseHealth, SwineProductQuantity)
        {
        }

        public override void Starve()
        {
            for (int i = 0; i < 3; i++)
            {
                base.Starve();
            }
        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            switch (food.FoodType)
            {
                case FoodType.Organic:
                case FoodType.Meat:
                    this.Health += food.HealthEffect * quantity * 2;
                    break;
                default:
                    throw new ArgumentException("Cow can only eat orgaic or meat food.");
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new ArgumentException("You cannot exploit dead swines.");
            }

            this.Die();

            return new Food(this.Id + ProductIdSuffix, ProductType.PorkMeat, FoodType.Meat, SwineProductQuantity, SwineProductHealthEffect);
        }
    }
}
