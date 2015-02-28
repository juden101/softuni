namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        private const int FoodPlantBaseWaterEffect = 1;

        public FoodPlant(string id, int health, int productionQuantity, int growTime, int healthEffect)
            : base(id, health, productionQuantity, growTime)
        {
            this.ProductHealthEffect = healthEffect;
        }

        public int ProductHealthEffect { get; set; }

        public override void Water()
        {
            this.Health += FoodPlantBaseWaterEffect;
        }

        public override void Wither()
        {
            for (int i = 0; i < 2; i++)
            {
                base.Wither();
            }
        }
    }
}
