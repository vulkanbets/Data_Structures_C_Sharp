


namespace FirstVisualStudioProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate MyVector object
            var vect1 = new MyVector<int>();

            Console.WriteLine("The capacity is = {0}\nThe size is = {1}", vect1.getcapacity(), vect1.size());

            vect1.print();

            vect1.push(11);

            Console.WriteLine("The capacity is = {0}\nThe size is = {1}", vect1.getcapacity(), vect1.size());

            vect1.print();


            vect1.push(22);

            Console.WriteLine("The capacity is = {0}\nThe size is = {1}", vect1.getcapacity(), vect1.size());

            vect1.print();


            vect1.push(33);

            Console.WriteLine("The capacity is = {0}\nThe size is = {1}", vect1.getcapacity(), vect1.size());

            vect1.print();


            vect1.push(44);

            Console.WriteLine("The capacity is = {0}\nThe size is = {1}", vect1.getcapacity(), vect1.size());

            vect1.print();





        }
    }
}



