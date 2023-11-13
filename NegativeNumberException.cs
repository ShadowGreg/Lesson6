using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{


    public class NegativeNumberException : Exception
    {
        //Создайте класс исключения NegativeNumberException,
        //который будет использоваться при попытке выполнения операции,
        //не поддерживающей отрицательные числа.

        public NegativeNumberException()
        { 
            
        
        }
        public NegativeNumberException(string massage) : base(massage)
        {


        }
        public NegativeNumberException(string massage, Exception ex) : base(massage, ex)
        {


        }

    }
}
