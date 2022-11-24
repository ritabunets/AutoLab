namespace Homework9_Dictionary
{
    class DictionaryAndLINQTasks
    {
        private static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }

        public static void Task1()
        {
            Console.WriteLine("---Task 1:");
            var people = new Dictionary<string, int>();
            people.Add("Rita", 26);
            people["Ivan"] = 25 ;
            Console.WriteLine(people.First());
        }

        public static void Task2()
        {
            Console.WriteLine("---Task 2:");
            var numbers = new List<int>() { 3, 2, 1, 0, 9, 8, 6, 7, 5, 4};
            var sordedNumbers = from n in numbers
                                orderby n
                                select n;

            var words = new List<string>() { "labas", "ritas", "laba", "dena", "zabas", "vakaras", "svike", "achu", "gerai", "iki" };
            var sordedWords = from w in words
                              orderby w descending
                              select w;

            var dictionary = sordedNumbers.Zip(sordedWords, (k, v) => new { k, v }).ToDictionary(e => e.k, e => e.v);
            foreach (var element in dictionary)
                Console.WriteLine(element);
        }

        public static void Task3()
        {
            Console.WriteLine("---Task 3:");
            var country = new Dictionary<string, City>()
            {
                {"vilnius", new City (population:544386, square:401)},
                {"klaipeda", new City (population: 152818, square: 98)},
                {"palanga", new City(population: 18207, square: 79)},
                {"kaunas",  new City(population: 295269, square: 157)},
                {"panevezhis", new City(population: 85885, square: 52.9)},
            };

            foreach (string key in country.Keys)
            {
                var city = country[key];
                Console.WriteLine($"{key}, population: {city.population}, square: {city.square}.");
            }

            Console.WriteLine("Cities ordered by square ASC:");
            var sortedBySquareASC = country.OrderBy(c => c.Value.square).ToList();
            foreach (var city in sortedBySquareASC)
                Console.WriteLine(city.Key);

            Console.WriteLine("Cities ordered by population DESC:");
            var sortedByPopulationDESC = country.OrderByDescending(c => c.Value.population).ToList();
            foreach (var city in sortedByPopulationDESC)
                Console.WriteLine(city.Key);

            Console.WriteLine("Population of all cities:");
            int countryPopulation = 0;
            foreach (string key in country.Keys)
            {
                var city = country[key];
                countryPopulation += city.population;
            }
            Console.WriteLine(countryPopulation);
        }
    }
}