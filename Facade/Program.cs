namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.DisplayItemInfo();
            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class ChooseItem
    {
        public void item()
        {
            Console.WriteLine("Piece of clothing: sweatshirt");
        }
    }
    // Subsystem ClassB" 
    class ChooseFabric
    {
        public void fabric()
        {
            Console.WriteLine("Fabric is cotton");
        }
    }


    // Subsystem ClassC" 
    class Color
    {
        public void itemColor()
        {
            Console.WriteLine("The color of the item is blue");
        }
    }

    // "Facade" 
    class Facade
    {
        ChooseItem pieceOfClothes;
        ChooseFabric material;
        Color colors;

        public Facade()
        {
            pieceOfClothes = new ChooseItem();
            material = new ChooseFabric();
            colors = new Color();
        }

        public void DisplayItemInfo()
        {
            Console.WriteLine("\nItem info: ");
            pieceOfClothes.item();
            material.fabric();
            colors.itemColor();
        }
    }
}
