using System.Text;

namespace Homework10
{
    public class GenericArray<T> where T : Human
    {
        private T[] _array;

        public GenericArray(int size)
        {
            _array = new T[] {};
        }

        public void AddElement(T element)
        {
            Array.Resize(ref _array, _array.Length + 1);
            _array.SetValue(element, _array.Length - 1);
        }

        public T GetElement(int index) => _array[index];

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= _array.Length-1)
            {
                throw new Exception("Set index is out of range, nothing is removed.");
            }
            for (int i = index; i < _array.Length - 1; i++)
                {
                    _array.SetValue(_array[i + 1], i);
                }
            Array.Resize(ref _array, _array.Length - 1);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < GetAraryLength(); i++)
            {
                stringBuilder.Append($"Human is {GetElement(i).FName} {GetElement(i).LName}\n");
            }

            if (typeof(T) == typeof(Woman))
            {
                stringBuilder.Append("There are only woman.\n");
            }
            else if (typeof(T) == typeof(Man))
            {
                stringBuilder.Append("There are only man.\n");
            }

            var finalString = stringBuilder.ToString();

            return finalString;
        }

        private int GetAraryLength() => _array.Length; // - надо его заюзать где-то
    }
}
