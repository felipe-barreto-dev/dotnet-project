using dotnet_project.Infra.Data;
using dotnet_project.Domain.Products;

namespace dotnet_project.Endpoints.Categories
{
    public class CategoryPost
    {
        public static string Template => "/categories";
        public static string[] Methods = new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;
        public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = new Category(categoryRequest.Name, "Test", "Test");

            if (!category.IsValid) {
                var errors = category.Notifications.GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
                return Results.ValidationProblem(errors);
            }
      
            context.Categories.Add(category);
            context.SaveChanges();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}