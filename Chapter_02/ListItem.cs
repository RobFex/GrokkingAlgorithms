namespace GrokkingAlgorithms
{
    public class ListItem<T>
    {
        private T data = default;
        public ListItem<T> Previous { get; set; }
        public ListItem<T> Next { get; set; }
        public T Data
        {
            get => data;
            set
            {
                if (value != null)
                    data = value;
                else throw new ArgumentException(nameof(value)); 
            }
        }
        
        public ListItem(T data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}