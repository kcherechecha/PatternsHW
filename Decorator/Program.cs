namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree tree = new ChristmasTree();
            ToyDecorator d1 = new ToyDecorator();
            LightsDecorator d2 = new LightsDecorator();

            // Link decorators
            d1.SetComponent(tree);
            d2.SetComponent(d1);
            d2.Decorate();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Decorate();
    }

    // "ConcreteComponent"
    class ChristmasTree : Component
    {
        public override void Decorate()
        {
            Console.WriteLine("Christmas Tree");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component tree;

        public void SetComponent(Component tree)
        {
            this.tree = tree;
        }
        public override void Decorate()
        {
            if (tree != null)
            {
                tree.Decorate();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ToyDecorator : Decorator
    {
        private string addedState;
        public override void Decorate()
        {
            base.Decorate();
            addedState = "Toy on";
            Console.WriteLine("You got a toy on a tree");
        }
    }

    // "ConcreteDecoratorB" 
    class LightsDecorator : Decorator
    {
        public override void Decorate()
        {
            base.Decorate();
            AddedBehavior();
            Console.WriteLine("Lights are on");
        }
        void AddedBehavior()
        { }
    }
}