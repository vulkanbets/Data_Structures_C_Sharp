


namespace FirstVisualStudioProject
{
    public class DataTypes
    {
        ////////////////////////////////////
        // Data Types and Variables Examples


        // Integer (whole number) - 4 bytes - Stores whole numbers from -2,147,483,648 to 2,147,483,647
        int myNum = 100000;



        // Long - 8 bytes - Stores whole numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
        // Note that you should end the value with an "L":
        long myLong = 15000000000L;



        // Floating point number
        // 4 bytes - Stores fractional numbers. Sufficient for storing 6 to 7 decimal digits
        // Note that you should end the value with an "F":
        float myFloat = 5.75F;



        // Floating point number
        // 8 bytes - Stores fractional numbers. Sufficient for storing 15 decimal digits
        // Note that you can end the value with a "D" (although not required):
        double myDoubleNum = 5.99D;



        // Scientific Numbers
        // A floating point number can also be a scientific number with an "e" to indicate the power of 10:
        float f1 = 35e3F;
        double d1 = 12E4D;



        // Boolean - 1 bit - Stores true or false values
        bool myBool = true;



        // Character - 2 bytes - Stores a single character/letter, surrounded by single quotes
        // The character must be surrounded by single quotes, like 'A' or 'c':
        char myLetter = 'D';



        // String - 2 bytes per character - Stores a sequence of characters, surrounded by double quotes
        // String values must be surrounded by double quotes:
        string myText = "Hello";
    }
}

