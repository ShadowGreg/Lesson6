using DZ5;
using Lesson6.Assistant;

namespace Lesson6 {
    internal class Program {
        private static double _number;
        private static double Num { get; set; } = 0;


        static void Main(string[] args) {
            ICalc _calc = new NewCalc();
            var convertDelegate = new ConvertDelegate(MyParse.DoubleTryParse);
            CalculateProgram program = new CalculateProgram(convertDelegate);
            List<string[]> lists = new() {
                new[] { "5", "3", "+" },
                new[] { "5", "3", "-" },
                new[] { "5", "3", "*" },
                new[] { "5", "3", "/" },
                new[] { "-5", "-3", "+" },
                new[] { "fasdfas", "asdf", "+" },
                new[] { "34523455", "3", "+" },
                new[] { "3", "45674567453", "-" },
                new[] { "F", "F", "F" },
            };

            for (int i = 0; i < lists.Count(); i++) {
                string[] list = lists[i];

                try {
                    program.Run<NewCalc>(list);
                    Console.WriteLine();
                }
                catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (NegativeNumberException ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (CalculatorExeption ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                Console.WriteLine("\n \n");
            }
        }
    }
}