


namespace FirstVisualStudioProject
{
    public class MyVector<T>
    {
        //////////
        // Private 

        // arr is the integer array which stores the address of the vector
        private T[] arr;

        // current is the number of elements currently present in the vector
        private int current;

        /////////
        // Public

        // Constructor
        public MyVector()
        {
            arr = new T[1];
            current = 0;
        }


        // Function to push a value into the end of MyVector
        public void push(T data)
        {
            // if the number of elements is equal to the
            // capacity, that means we don't have space to
            // accommodate more elements. We need to double the
            // capacity
            if(current == arr.Length)
            {
                int new_capacity = 2 * arr.Length;
                var temp = new T[new_capacity];
                // copying old array elements to new array
                for(int i = 0; i < arr.Length; i++)
                    { temp[i] = arr[i]; }
                // Assign old array to new array
                arr = temp;
            }
            // Insert data into the last element
            arr[current] = data;
            current++;
        }



        // function to add element at any index
        void push(int data, int index)
        {
            // if index is equal to capacity then this
            // function is same as push defined above
            //if (index == capacity)
            //    push(data);
            //else
            //    arr[index] = data;
        }




        // function to delete end element
        public void pop() { if(current > 0) current--; }


        // function to get size of the vector
        public int size() { return current; }

        // function to get capacity of the vector
        public int getcapacity() { return arr.Length; }



        // function to print array elements
        public void print()
        {
            for(int i = 0; i < current; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

    }
}


