namespace Builder
{
    class Program
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}",
                    dough, sauce, topping);
            }
        }
        //Abstract Builder
        abstract class PizzaBuilder
        {protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }
            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }
        //Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() {
                pizza.SetTopping("ham+pineapple"); }
        }
        //Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("panbaked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() {
                pizza.SetTopping("pepparoni+salami"); }
        }

        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                pizza.SetDough("panbaked");
            }

            public override void BuildSauce()
            {
                pizza.SetSauce("sweet");
            }

            public override void BuildTopping()
            {
                pizza.SetTopping("mozarella+tomatoes+basil");
            }
        }
        /** "Director" */
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder =
                pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
            }
        }
        /** A customer ordering a pizza. */
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Console.WriteLine("Hawaiian Pizza");
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new
                    HawaiianPizzaBuilder();
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza = waiter.GetPizza();
                pizza.Info();
                Console.WriteLine("\n");
                
                Console.WriteLine("Spicy Pizza");
                Waiter waiter0 = new Waiter();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                waiter0.SetPizzaBuilder(spicyPizzaBuilder);
                waiter0.ConstructPizza();
                Pizza pizza1 = waiter0.GetPizza();
                pizza1.Info();
                Console.WriteLine("\n");
                
                Console.WriteLine("Pizza Margarita");
                Waiter waiter1 = new Waiter();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
                waiter1.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter1.ConstructPizza();
                Pizza pizza2 = waiter1.GetPizza();
                pizza2.Info();
                Console.ReadKey();
            }
        }
    }
}