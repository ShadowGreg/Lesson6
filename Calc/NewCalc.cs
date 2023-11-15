using DZ5;

namespace Lesson6;

public class NewCalc: Calc {
    public override void Sum(double x, double y) {
        if (x < 0 || y < 0) {
            throw new NegativeNumberException("The numbers cannot be negative.");
        }

        Result = x + y;
        PrintResult();
    }
}