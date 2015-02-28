namespace FarmersCreed.Units
{
    using System;

    class Cow : Animal
    {
        private const int CowBaseHealth = 15;
        private const int CowProductHealthEffect = 4;
        private const int CowProductQuantity = 6;
        private const int CowLossPerMilk = 2;

        public Cow(string id)
            : base(id, CowBaseHealth, CowProductQuantity)
        {
        }

        public override void Eat(Interfaces.IEdible product, int quantity)
        {
            switch(product.FoodType)
            {
                case FoodType.Organic:
                    this.Health += product.HealthEffect * quantity;
                    break;
                case FoodType.Meat:
                    this.Health -= product.HealthEffect * quantity;
                    break;
                default:
                    throw new ArgumentException("Cow can only eat orgaic or meat food.");
            }
        }

        public override Product GetProduct()
        {
            if(!this.IsAlive)
            {
                throw new ArgumentException("You cannot exploit dead cows.");
            }

            this.Health -= CowLossPerMilk;

            return new Food(this.Id + ProductIdSuffix, ProductType.Milk, FoodType.Organic, CowProductQuantity, CowProductHealthEffect);
        }
    }
}
