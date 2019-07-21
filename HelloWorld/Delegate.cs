namespace HelloWorld
{
    class Delegate
    {
        delegate int TestDelegate(int x);

        public Delegate()
        {
            TestDelegate dlgt = Pow;
            dlgt += Plus;
            int result = dlgt(10);
        }

        static public int Pow(int x)
        {
            return (x * x);
        }

        static public int Plus(int x)
        {
            return (x + x);
        }
    }    
}
