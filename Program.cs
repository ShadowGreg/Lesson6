namespace Lesson6
{
    internal class Program {
        private static double _number;
        public static double Num { get; set; } = 0;

        static void Main(string[] args)
        {
            try
            {
                List<string> list = new List<string>() {
                    "1,5",
                    "2,1",
                    "-3",
                    "FGSDGF",
                    "5.6",
                    "6,9999999",
                }; 
                _number = Num;
                var flag = DoubleTryParse("4.5", out _number);
                Console.WriteLine(flag);
                Console.WriteLine(Num);
                
                double[] parsedNumbers = list.Select(
                    num => DoubleParse(
                        num.ToString(),
                        out double result) ? result : 0)
                    .ToArray();
                
                
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            try
            {
                double result = CalculateSum(5, 3);
                Console.WriteLine(result);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool DoubleParse(string myString, out double number) {
            Console.WriteLine("input -> "+ myString);
            var flag = DoubleTryParse(myString, out number);
            Console.WriteLine("output -> "+ number);
            return flag;
        }

        static bool DoubleTryParse(string myString, out double number)
        {
            number = Double.MinValue;
            try
            {
                number = double.Parse(myString);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        
        static double CalculateSum(double a, double b)
        {
            if (a < 0 || b < 0)
            {
                throw new NegativeNumberException("The numbers cannot be negative.");
            }
            
            return a + b;
        }
    }
}