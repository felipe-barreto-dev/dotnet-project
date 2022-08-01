using System.Diagnostics.Contracts;
using Flunt.Validations;

namespace dotnet_project.Domain.Products;

public class Product : Entity {
    public string Name { get; set; }
    public bool HasStock { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }

    public Product(string name, Guid categoryId, string description) {

        var contract = new Contract<Product>()
            .IsNullOrEmpty(name, "Name")
            .IsNull(categoryId, "CategoryId")
            .IsNullOrEmpty(description, "Description");

        AddNotifications(contract);

        Name = name;
        Active = true;
    }

}
 