namespace DZ5 {
    public delegate double ConvertDelegate(string input);

    public class CalculateProgram {
        private readonly ConvertDelegate _convertDelegate;

        public CalculateProgram(ConvertDelegate convertDelegate) {
            _convertDelegate = convertDelegate;
        }

        public void Run<T>(string[] args) where T : Calc, new() {
            bool exit = true;

            while (exit) {
                var calc = new T();
                calc.MyEventHandler += Calc_MyEventHandler;
                double number1, number2;
                string symbol;

                try {
                    Console.Write("Enter first number  > ");
                    number1 = _convertDelegate(args[0]);
                    Console.WriteLine(args[0]);

                    Console.Write("Enter second number > ");
                    number2 = _convertDelegate(args[1]);
                    Console.WriteLine(args[1]);

                    Console.Write("Select an action '+', '-', '/', '*'  > ");
                    symbol = args[2];
                    Console.WriteLine(args[2]);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    throw new FormatException("Invalid data format");
                }
                finally {
                    Console.WriteLine("\n \n");
                }


                switch (symbol) {
                    case "+":
                        calc.Sum(number1, number2);
                        break;
                    case "-":
                        calc.Sub(number1, number2);
                        break;
                    case "/":

                        try {
                            calc.Divide(number1, number2);
                        }

                        catch (CalculatorDivideByZeroException ex) {
                            Console.WriteLine(ex.Message);
                        }

                        catch (CalculatorExeption ex) {
                            Console.WriteLine(ex);
                        }

                        catch (Exception ex) {
                            Console.WriteLine(ex);
                        }

                        break;
                    case "*":
                        calc.Multy(number1, number2);
                        break;
                }

                Console.WriteLine("Continue ?");
                Console.WriteLine("Press F to finish");

                if (args.Contains("F")) {
                    exit = false;
                }

                // Console.Clear();
                break;
            }
        }

        private static void Calc_MyEventHandler(object? sender, EventArgs e) {
            if (sender is Calc) {
                Console.WriteLine($"Answer: {((Calc)sender).Result}");
            }
        }
    }
}