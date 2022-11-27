namespace Homework10
{
    public class GenericArray<T> where T : Human
    {
        private T[] _array;

        public GenericArray(int size)
        {
            _array = new T[size + 1];
        }

        public int GetAraryLength() => _array.Length;

        public void AddElement(int index, T element)
        {
            _array[index] = element;
        }

        public T GetElement(int index) => _array[index];

        public void RemoveElement(ref T[] _array, int index)
        {
            T[] tmp = new T[_array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                tmp[i] = _array[i];
            }
            for (int i = index; i < tmp.Length; i++)
            {
                tmp[i] = _array[i + 1];
            }
            _array = tmp;
        }

        public static void ToString(GenericArray<T> _array)
        {
            if (typeof(T) == typeof(Woman))
            {
                Console.WriteLine("There are only woman.");
            }
            else if (typeof(T) == typeof(Man))
            {
                Console.WriteLine("There are only man.");
            }
            for (int i = 0; i < _array.GetAraryLength()-1; i++)
            {
                Console.WriteLine($"Human is {_array.GetElement(i).FName} {_array.GetElement(i).LName}");
            }
        }
    }
}
