using System;

namespace HelloWorld
{
    public class Oroklodes
    {
        public Oroklodes()
        {
            Animal aa = new Animal("as");
            Animal ac = new Crocodile("Sh1t");
            Crocodile cc = new Crocodile("Sh1t");

            aa.Eat();
            ac.Eat();
            cc.Eat();

            ((Crocodile)ac).Sleep();

            Animal[] animalArray = new Animal[2];

            animalArray[0] = new Animal("as");
            animalArray[1] = new Crocodile("Sh1t");
            animalArray[0].Eat();
            animalArray[1].Eat();
        }
    }

    class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public virtual void Eat()
        {
            Console.WriteLine("Az állat eszik");
        }
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        public new void Eat()
        {
            Console.WriteLine("Kutya eszik");
        }
    }
    class Crocodile : Animal
    {
        public Crocodile(string name) : base(name)
        {
        }

        public override void Eat()
        {
            Console.WriteLine("Kroki eszik");
        }

        public void Sleep()
        {
            Console.WriteLine("Kroki alszik");
        }
    }
}
