namespace StacksAndQueuesHomework
{
    public class Item
    {
        public int Value
        {
            get;
            private set;
        }

        public Item PrevItem
        {
            get;
            private set;
        }

        public Item(int value, Item prevItem)
        {
            this.Value = value;
            this.PrevItem = prevItem;
        }
    }
}