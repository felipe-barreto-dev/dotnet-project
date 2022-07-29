using System.Diagnostics.Contracts;
using Flunt.Validations;

namespace dotnet_project.Domain.Products;

public class Category : Entity {
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name) {
        var contract = new Contract<Category>()
            .IsNotNull(name, "Name");
    
        AddNotifications(contract);
        
        Name = name;
        Active = true;
    }

}