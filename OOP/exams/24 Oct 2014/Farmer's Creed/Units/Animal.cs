namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        private const int AnimalBaseStarveRate = 1;

        public Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public virtual void Starve()
        {
            this.Health -= AnimalBaseStarveRate;
        }

        public abstract void Eat(IEdible product, int quantity);
    }
}
