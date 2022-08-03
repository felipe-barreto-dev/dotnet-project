using System.Diagnostics.Contracts;
using Flunt.Validations;

namespace dotnet_project.Domain.Products;

public class Category : Entity {
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createdBy, string editedBy) {
        var contract = new Contract<Category>()
            .IsNullOrEmpty(name, "Name")
            .IsGreaterOrEqualsThan(name, 3, "Name")
            .IsNullOrEmpty(createdBy, "CreatedBy")
            .IsNullOrEmpty(editedBy, "EditeBy");
    
        AddNotifications(contract);
        
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;
    }

}