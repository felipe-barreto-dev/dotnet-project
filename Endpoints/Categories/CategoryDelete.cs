using System;
using dotnet_project.Infra.Data;
using dotnet_project.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_project.Endpoints.Categories
{
    public class CategoryDelete
    {
        public static string Template => "/categories/{id}";
        public static string[] Methods = new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
        {
            var category = context.Categories.Where(c => c.Id == Id).First();
            context.Categories.Remove(category);
            context.SaveChanges();
            return Results.Ok();
        }
    }
}