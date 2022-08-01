using dotnet_project.Domain.Products;

namespace dotnet_project.Endpoints.Products
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ProductRequest(string name) {
            Name = name;
            Active = true;
        }
    }
}