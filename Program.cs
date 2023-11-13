namespace Lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lesson1
            /*
            if (MyTryParse("4", out int num))
            {
                Console.WriteLine(num);
            }
            */
            //lesson2
            
            try
            {
                ProcessNumber(-5);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
                Console.WriteLine();
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            catch { } 
        }
        static bool MyTryParse(string myString, out int num)
        {
            num = 0;
            try
            {          
                num = Convert.ToInt32(myString);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        //Создайте класс исключения NegativeNumberException,
        //который будет использоваться при попытке выполнения операции,
        //не поддерживающей отрицательные числа.
       static void ProcessNumber(int numder)
        {
            if (numder < 0)
            {
                throw new NegativeNumberException("Ваше число отрицательное", new Exception("123"));
            }
            Console.WriteLine(numder);
        }

        //Добавьте обработку собственного исключения, а также кода,
        //который обрабатывает вложенное исключение(InnerException)
        //для предоставления более детальной информации.


    }
}