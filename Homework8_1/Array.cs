namespace Homework8_1
{
    public class Array
    {
        public static void ShowMassiveElement()
        {
            int[] massive = { 8, 7, 1, 4, 2 };

            Console.WriteLine("Input index of element in massive:");
            try
            {
                string? inputedValue = Console.ReadLine();
                string? checkedValue = inputedValue.Equals(string.Empty) ? null : inputedValue;
                int inputtedNumber = Int32.Parse(checkedValue);

                int massiveElement = massive[inputtedNumber];
                Console.WriteLine($"Massive element that has index {inputedValue} has value {massiveElement}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException occurred: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FormatException occurred: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"OverflowException occurred: {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"IndexOutOfRangeException occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption occurred: {ex.Message}");
            }
        }
    }
}
