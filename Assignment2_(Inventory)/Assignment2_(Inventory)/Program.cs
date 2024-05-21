
namespace Assignment2__Inventory_
{
    internal class Program
    {
        public class Item
        {
            private int Id;
            private string Name;
            private double Price;
            private int Quantity;

            public Item(int id, string name, double price, int quantity)
            {
                this.Id = id;
                this.Name = name;
                this.Price = price;
                this.Quantity = quantity;
            }

            public int GetId() { return Id; }
            public string GetName() { return Name; }
            public double GetPrice() { return Price; }
            public int GetQuantity() { return Quantity; }

            public void SetId(int id) { this.Id = id; }
            public void SetName(string name) { this.Name = name; }
            public void SetPrice(double price) { this.Price = price; }
            public void SetQuantity(int quantity) { this.Quantity = quantity; }

            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
            }
        }

        public class Electronics : Item
        {
            private string Warranty;

            public Electronics(int id, string name, double price, int quantity, string warranty)
                : base(id, name, price, quantity)
            {
                this.Warranty = warranty;
            }

            public string GetWarranty() { return Warranty; }
            public void SetWarranty(string warranty) { this.Warranty = warranty; }

            public override string ToString()
            {
                return base.ToString() + $", Warranty: {Warranty}";
            }
        }

        public class Grocery : Item
        {
            private string ShelfLife;

            public Grocery(int id, string name, double price, int quantity, string shelfLife)
                : base(id, name, price, quantity)
            {
                this.ShelfLife = shelfLife;
            }

            public string GetShelfLife() { return ShelfLife; }
            public void SetShelfLife(string shelfLife) { this.ShelfLife = shelfLife; }

            public override string ToString()
            {
                return base.ToString() + $", Shelf Life: {ShelfLife}";
            }
        }

        public class Inventory
        {
            public List<Item> Items = new List<Item>();

            public void DisplayAllItems()
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine(Items[i]);
                }
            }

            public Item FindById(int id)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].GetId() == id)
                        return Items[i];
                }
                return null;
            }

            public void DisplayFindById()
            {
                Console.WriteLine("Enter Id to display:");
                int id = Convert.ToInt32(Console.ReadLine());

                Item item = FindById(id);
                if (item != null)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("No data found");
                }
            }

            public void DeleteItem()
            {
                Console.Write("Enter Item ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Item item = FindById(id);
                if (item != null)
                {
                    Items.Remove(item);
                    Console.WriteLine("Item deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }

            public void UpdateItem()
            {
                Console.Write("Enter Item ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Item item = FindById(id);
                if (item != null)
                {
                    Console.Write("Enter new Item Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    if (name != null && name != "")
                    {
                        item.SetName(name);
                    }

                    Console.Write("Enter new Item Price (leave blank to keep current): ");
                    double priceInput = Convert.ToDouble(Console.ReadLine());
                    if (priceInput != null)
                    {
                            
                            item.SetPrice(priceInput);
                        
                    }
                    Console.Write("Enter new Item Quantity (leave blank to keep current): ");
                    int quantityInput = Convert.ToInt32(Console.ReadLine());
                    if (quantityInput != null)
                    {
                           
                            item.SetQuantity(quantityInput);   
                    }

                    if (item is Grocery groceryItem)
                    {
                        Console.Write("Enter new Shelf Life (leave blank to keep current): ");
                        string shelfLifeInput = Console.ReadLine();
                        if (shelfLifeInput != null && shelfLifeInput != "")
                        {
                            groceryItem.SetShelfLife(shelfLifeInput);
                        }
                    }
                    else if (item is Electronics electronicItem)
                    {
                        Console.Write("Enter new Warranty (leave blank to keep current): ");
                        string warrantyInput = Console.ReadLine();
                        if (warrantyInput != null && warrantyInput != "")
                        {
                            electronicItem.SetWarranty(warrantyInput);
                        }
                    }

                    Console.WriteLine("Item updated successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }

            public void AddItems()
            {
                Console.WriteLine("Enter Id:");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Price:");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Quantity:");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Category:");
                Console.WriteLine("1. Electronics");
                Console.WriteLine("2. Grocery");

                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Enter Warranty:");
                        string warranty = Console.ReadLine();
                        Items.Add(new Electronics(id, name, price, quantity, warranty));
                        break;
                    case 2:
                        Console.WriteLine("Enter Shelf Life:");
                        string shelfLife = Console.ReadLine();
                        Items.Add(new Grocery(id, name, price, quantity, shelfLife));
                        break;
                    default:
                        Console.WriteLine("Enter Correct Option");
                        break;
                }
            }

            public void Run()
            {
                bool exit = false;
                while (exit!=true)
                {
                    Console.WriteLine("\nInventory Management System");
                    Console.WriteLine("1. Add Item");
                    Console.WriteLine("2. Display All Items");
                    Console.WriteLine("3. Display Item by Id");
                    Console.WriteLine("4. Update Item");
                    Console.WriteLine("5. Delete Item");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1 || input > 6)
                    {
                        Console.WriteLine("Enter Option between 1-6");
                        continue;
                    }
                    switch (input)
                    {
                        case 1:
                            AddItems();
                            break;
                        case 2:
                            DisplayAllItems();
                            break;
                        case 3:
                            DisplayFindById();
                            break;
                        case 4:
                            UpdateItem();
                            break;
                        case 5:
                            DeleteItem();
                            break;
                        case 6:
                            exit = true;
                            break;
                    }
                }
            }

            static void Main(string[] args)
            {
                Inventory inv = new Inventory();
                inv.Run();
            }
        }
    }
}
