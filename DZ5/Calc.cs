namespace DZ5
{
    public class Calc : ICalc
    {
        public double Result { get; set; } = 0D;
        private Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        protected void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }
        public void Divide(double x, double y)
        {
            
            if (y != 0)
            {
                Result = x / y;
            }
            else
            {
                Console.WriteLine("Ошибка: деление на ноль");
                throw new CalculatorDivideByZeroException();
            }
          
            PrintResult();
        }

        public void Multy(double x, double y)
        {
            Result = x*y;
            PrintResult();
        }

        public void Sub(double x, double y)
        {
            Result = x - y;
            PrintResult();
        }

        public virtual void Sum(double x, double y)
        {
            Result = x +y;
            PrintResult();
        }

        [Obsolete("Obsolete")]
        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
                Result = res;
                Console.WriteLine("Последнее действие отменено, результат равен: ");
                PrintResult();
            }
            else
            {
                throw new ExecutionEngineException("Невозможно отменить последнее действие");
            }
        }

    }
}
