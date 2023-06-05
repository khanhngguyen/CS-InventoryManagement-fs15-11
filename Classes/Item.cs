namespace Classes;

class Item {
    private readonly string _barCode;
    private readonly string _name;
    private int _quantity;
    private int _quantityInInventory;

    public string BarCode
    {
        get { return _barCode; }
    }

    public string Name 
    {
        get { return _name; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set {
            if (value < 0)
            {
                throw new Exception("Quantity can not be negative");
            }
            else _quantity = value;
        }
    }
    public int QuantityInInventory {
        get { return _quantityInInventory; }
        set {
            _quantityInInventory = value;
        }
    }

    public Item(string barcode, string name, int quantity)
    {
        _barCode = barcode;
        _name = name;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity < 0)
        {
            throw new Exception("quanity can not be negative");
        }
        else _quantity += quantity;
    }

    public void DecreaseQuantity(int quantity)
    {
        if (quantity > Quantity)
        {
            throw new Exception("can not decrease more than original quantity");
        }
        else _quantity -= quantity;
    }
}
