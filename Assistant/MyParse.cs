namespace Lesson6.Assistant;

internal static class MyParse {
    public static double DoubleTryParse(string myString) {
        if (double.TryParse(myString, out double result)) {
            return result;
        }

        throw new FormatException("Can't convert string to number");
    }
}