// See https://aka.ms/new-console-template for more information
using System;
using Classes;

internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine("Create 4 items: item1, item2, item4, item4");
        Item item1 = new Item("10010", "Item1", 10);
        Item item2 = new Item("10020", "Item2", 15);
        Item item3 = new Item("20010", "Item3", 20);
        Item item4 = new Item("12001", "Item4", 25);
        Console.WriteLine("");

        Printer printer = new Printer();
        printer.PrintItem(item1);
        printer.PrintItem(item2);
        printer.PrintItem(item3);
        printer.PrintItem(item4);
        Console.WriteLine($"Item1 original quantity: {item1.Quantity}");
        Console.WriteLine($"Item4 original quantity: {item4.Quantity}");
        Console.WriteLine("Increase quantity for item1 by 10 & decrease quantity for item4 by 10");
        item1.IncreaseQuantity(10);
        // item4.DecreaseQuantity(30);
        item4.DecreaseQuantity(10);
        Console.WriteLine($"After, Item1 quantity: {item1.Quantity}, Item4 quantity: {item4.Quantity}");
        Console.WriteLine("");

        Console.WriteLine("Create inventory with max capacity of 50 & add 4 items into inventory");
        Inventory inventory = Inventory.Instance(50);
        inventory.AddItem(item1, 20);
        inventory.AddItem(item2, 10);
        inventory.AddItem(item3, 15);
        inventory.AddItem(item4, 15);
        printer.PrintInventory(inventory);
        inventory.ViewInventory();
        Console.WriteLine("");

        Console.WriteLine("Remove Item1 in inventory");
        inventory.RemoveItem(item1.BarCode);
        printer.PrintInventory(inventory);
        inventory.ViewInventory();
        Console.WriteLine("");

        Console.WriteLine("Increase Item2 by 2, Decrease Item3 by 5, & add Item4 by 5");
        inventory.IncreaseQuantity(2, item2.BarCode);
        inventory.DecreaseQuantity(5, item3.BarCode);
        inventory.AddItem(item4, 5);
        printer.PrintInventory(inventory);
        inventory.ViewInventory();

        // inventory.AddItem(myItem2, 2);
        // Console.WriteLine(myItem.Quantity);
        // Console.WriteLine(myItem.QuantityInInventory);
        // // inventory.RemoveItem("barcodehihi");
        // Console.WriteLine("total amount" + inventory.TotalAmount);
        // Console.WriteLine("quantity" + myItem.Quantity);
        // Console.WriteLine("quantity in invet" + myItem.QuantityInInventory);
        // inventory.IncreaseQuantity(1, "barcodehihi");
        // Console.WriteLine("total amount" + inventory.TotalAmount);
        // Console.WriteLine("quantity" + myItem.Quantity);
        // Console.WriteLine("quantity in invet" + myItem.QuantityInInventory);
        // inventory.ViewInventory();
        // Console.WriteLine(inventory.Items.Count);
    }

}

