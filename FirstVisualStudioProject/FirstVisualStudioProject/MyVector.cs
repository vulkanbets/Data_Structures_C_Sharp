


namespace FirstVisualStudioProject
{
    public class MyVector<T>
    {
        // arr is the integer pointer
        // which stores the address of the vector
        private T[] arr;

        // capacity is the total storage
        // capacity of the vector
        private int capacity;

        // current is the number of elements
        // currently present in the vector
        private int current;


        // Constructor
        public MyVector()
        {
            arr = new T[1];
            capacity = 1;
            current = 0;
        }


    }
}


