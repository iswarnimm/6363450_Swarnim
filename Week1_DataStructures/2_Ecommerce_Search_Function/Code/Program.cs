using System;

class Program
{
    static Product LinearSearch(Product[] products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

    static Product BinarySearch(Product[] products, int targetId)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (products[mid].ProductId == targetId)
                return products[mid];
            else if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void Main(string[] args)
    {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(203, "Shirt", "Clothing"),
            new Product(150, "Smartphone", "Electronics"),
            new Product(120, "Book", "Stationery"),
            new Product(302, "Shoes", "Footwear")
        };

        Console.WriteLine("Original Product List:");
        foreach (var p in products)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\n?? Linear Search for Product ID 150:");
        var linearResult = LinearSearch(products, 150);
        Console.WriteLine(linearResult != null ? $"Found: {linearResult}" : "Product not found");

        // Sort by ProductId before Binary Search
        Array.Sort(products, (p1, p2) => p1.ProductId.CompareTo(p2.ProductId));

        Console.WriteLine("\nSorted Product List (for Binary Search):");
        foreach (var p in products)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\n?? Binary Search for Product ID 150:");
        var binaryResult = BinarySearch(products, 150);
        Console.WriteLine(binaryResult != null ? $"Found: {binaryResult}" : "Product not found");
    }
}
