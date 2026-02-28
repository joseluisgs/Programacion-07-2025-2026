namespace Productos.Models;

public record Product(int Id, string Name, int Supplier, int Category, double UnitPrice, int UnitsInStock)
    : IComparable<Product>
{
    public int CompareTo(Product? other)
    {
        if (other is null) return 1;
        return UnitsInStock.CompareTo(other.UnitsInStock);
    }
}
