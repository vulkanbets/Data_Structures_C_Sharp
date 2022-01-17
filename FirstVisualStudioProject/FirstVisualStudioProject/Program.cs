


namespace FirstVisualStudioProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate MyVector object
            var vect1 = new MyVector<int>();

            Console.WriteLine("The capacity is = {0}\nThe size is = {1}", vect1.getcapacity(), vect1.size());


        }
    }
}



