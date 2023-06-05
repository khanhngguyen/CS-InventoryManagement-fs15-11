namespace Classes;

class Inventory {
    private static Inventory _instance = new Inventory(50);
    private List<Item> _items;
    private int _maxCapacity;
    private int _totalAmount;

    public List<Item> Items
    {
        get { return _items; }
    }

    public int MaxCapacity 
    {
        get { return _maxCapacity; }
        set 
        {
            if (value < 1)
            {
                throw new Exception("Max capacity can not be less than 1 ");
            }
            else _maxCapacity = value;
        }
    }
    public int TotalAmount 
    {
        get { return _totalAmount; }
        set 
        {
            int total = 0;
            foreach (Item item in _items)
            {
                total += item.Quantity;
            }
            _totalAmount = total;
        }
    }

    private Inventory(int max) {
        _items = new List<Item>();
        MaxCapacity = max;
    }
    public static Inventory Instance(int max)
    {
        if (_instance == null)
        {
            _instance = new Inventory(max);
        }
        return _instance;
    }

    public bool AddItem(Item item, int quantity)
    {
        //if inventory reaches maxCapacity
        if (quantity < 1) throw new Exception("quantity can not be negative");
        if (_totalAmount + quantity >= _maxCapacity)
        {
            Console.WriteLine("max capacity reached, can not add more item");
            return false;
        }
        //check if items already existed in inventory
        var existed = _items.Find(i => i.BarCode == item.BarCode);
        if (existed != null)
        {
            existed.Quantity -= quantity;
            existed.QuantityInInventory += quantity;
            _totalAmount += quantity;
        }
        else
        {
            if (quantity > item.Quantity) throw new Exception("can not add more then item\'s original quantity");
            else {
                _items.Add(item);
                item.Quantity -= quantity;
                item.QuantityInInventory += quantity;
                _totalAmount += quantity;
            }
        }
        return true;
    }
    public bool RemoveItem(string barcode)
    {
        var existed = _items.Find(i => i.BarCode == barcode);
        if (existed != null)
        {
            _items.Remove(existed);
            _totalAmount -= existed.QuantityInInventory;
            existed.Quantity += existed.QuantityInInventory;
            existed.QuantityInInventory = 0;
            return true;
        }
        else return false;
    } 
    public void IncreaseQuantity(int amount, string barcode)
    {
        //check barcode
        if (_totalAmount >= _maxCapacity)
        {
            throw new Exception("max capacity reached, can not increase more");
        }
        var existed = _items.Find(i => i.BarCode == barcode);
        if (existed != null)
        {
            if (amount > existed.Quantity) throw new Exception("can not increase amount exceeding item\'s original quantity");
            else {
                existed.QuantityInInventory += amount;
                _totalAmount += amount;
                existed.Quantity -= amount;
            }
        }
        else throw new Exception("barcode does not match any item in inventory");
    }
    public void DecreaseQuantity(int amount, string barcode)
    {
        //check barcode
        var existed = _items.Find(i => i.BarCode == barcode);
        if (existed != null)
        {
            existed.QuantityInInventory -= amount;
            _totalAmount -= amount;
            existed.Quantity += amount;
        }
        else throw new Exception("barcode does not match any item in inventory");
    }
    public void ViewInventory()
    {
        foreach(Item item in _items)
        {
            Console.WriteLine($"Barcode: {item.BarCode}, Item\'s name: {item.Name}, current Quantity in Inventory:{item.QuantityInInventory}");
        }
    }

    //Destructor
    ~Inventory()
    {
        Console.WriteLine("Inventory is destroyed");
    }
}