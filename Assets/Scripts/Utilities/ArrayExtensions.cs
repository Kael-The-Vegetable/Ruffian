
using Deck;

public static class ArrayExtensions
{
    public static T[] GetRange<T>(this T[] array, int startIndex, int endIndex)
    {
        int range = endIndex - startIndex;
        if (range > array.Length) range = array.Length;

        T[] newArray = new T[range];

        for (int i = startIndex; i < endIndex; i++)
        {
            newArray[i] = array[i];
        }
        return newArray;
    }
}
