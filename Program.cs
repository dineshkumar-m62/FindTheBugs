using System;

namespace CodeReview
{
    class LivingBeing
    {
        public string name;
        public LivingBeing? Parent = null;

        public LivingBeing(string name)
        {
            this.name = name;
        }

        public virtual int NumberOfLimbs() { return 0; }
        public virtual int NumberOfDigits() { return 0; }

        public LivingBeing RootAncestor()
        {
            if (Parent != null)
                return Parent.RootAncestor();
            return this;
        }

        public int DigitsPerLimb()
        {
            return NumberOfDigits() / NumberOfLimbs();
        }
    }

    class Human : LivingBeing
    {
        public Human(string name) : base(name) { }

        public override int NumberOfLimbs() { return 4; }
        public override int NumberOfDigits() { return 10; }
    }

    class JellyFish : LivingBeing
    {
        public JellyFish(string name) : base(name) { }

        public override int NumberOfLimbs() { return 0; }
        public override int NumberOfDigits() { return 0; }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                LivingBeing tom = new LivingBeing("Tom");
                LivingBeing jane = new LivingBeing("Jane");
                LivingBeing john = new Human("John");

                john.Parent = jane;
                jane.Parent = tom;

                LivingBeing root = john.RootAncestor();
                Console.WriteLine(john.name + "'s oldest ancestor is " + root.name); // should be Tom
                Console.WriteLine("Tom's parent is " + (tom.Parent != null ? tom.Parent.name : "Unknown"));

                JellyFish jelly = new JellyFish("Jelly");
                int x = jelly.DigitsPerLimb();
                Console.WriteLine("Digits per limb for JellyFish: " + x);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            
        }
    }
}