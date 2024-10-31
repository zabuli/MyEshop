using MyEshop.Core.Entities;

namespace MyEshop.TestUtilities.Mocks;

public static class MockProducts
{
    public static List<Product> Products =
        new()
        {
            new()
            {
                Id = 1, 
                Name = "Mock Product 1", 
                ImgUri = "www.images.com/image1.png",
                Description = "Description 1",
                Price = 10.0m
            },
            new()
            {
                Id = 2, 
                Name = "Mock Product 2", 
                ImgUri = "www.images.com/image2.png",
                Description = "Description 2",
                Price = 20.0m
            },
            new()
            {
                Id = 3,
                Name = "Mock Product 3", 
                ImgUri = "www.images.com/image3.png",
                Description = "Description 3",
                Price = 210.0m
            }
        };
}