namespace Classes;

class Printer {
    public void PrintItem(Item item)
    {
        Console.WriteLine($"Item name: {item.Name}, Item\'s barcode: {item.BarCode}");
    }
    public void PrintInventory(Inventory inventory)
    {
        Console.WriteLine($"Inventory information, unique items: {inventory.Items.Count}, total amount of items: {inventory.TotalAmount}");
    }
}