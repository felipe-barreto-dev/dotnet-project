using dotnet_project.Infra.Data;
using dotnet_project.Domain.Products;

namespace dotnet_project.Endpoints.Products;

public class ProductPost {

    public static string Template => "/products";
    public static string[] Methods = new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ProductRequest productRequest, ApplicationDbContext context) {

        var product = new Product(productRequest.Name, productRequest.CategoryId, productRequest.Description);

        if (!product.IsValid) {
            return Results.BadRequest(product.Notifications);
        }
        
        context.Products.Add(product);
        context.SaveChanges();

        return Results.Created($"products/{product.Id}", product.Id);
    }

}