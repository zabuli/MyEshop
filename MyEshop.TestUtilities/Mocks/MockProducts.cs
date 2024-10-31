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
            },
            new()
            {
                Id = 4,
                Name = "Mock Product 4", 
                ImgUri = "www.images.com/image4.png",
                Description = "Description 4",
                Price = 240.0m
            },
            new()
            {
                Id = 5,
                Name = "Mock Product 5", 
                ImgUri = "www.images.com/image5.png",
                Description = "Description 5",
                Price = 250.0m
            },
            new()
            {
                Id = 6,
                Name = "Mock Product 6", 
                ImgUri = "www.images.com/image6.png",
                Description = "Description 6",
                Price = 260.0m
            },
            new()
            {
                Id = 7,
                Name = "Mock Product 7", 
                ImgUri = "www.images.com/image7.png",
                Description = "Description 7",
                Price = 270.0m
            },
            new()
            {
                Id = 8,
                Name = "Mock Product 8", 
                ImgUri = "www.images.com/image8.png",
                Description = "Description 8",
                Price = 280.0m
            },
            new()
            {
                Id = 9,
                Name = "Mock Product 9", 
                ImgUri = "www.images.com/image9.png",
                Description = "Description 9",
                Price = 290.0m
            },
            new()
            {
                Id = 10,
                Name = "Mock Product 10", 
                ImgUri = "www.images.com/image10.png",
                Description = "Description 10",
                Price = 2110.0m
            },
            new()
            {
                Id = 11,
                Name = "Mock Product 11", 
                ImgUri = "www.images.com/image11.png",
                Description = "Description 11",
                Price = 211.0m
            },
            new()
            {
                Id = 12,
                Name = "Mock Product 12", 
                ImgUri = "www.images.com/image12.png",
                Description = "Description 12",
                Price = 212.0m
            },
            new()
            {
                Id = 13,
                Name = "Mock Product 13", 
                ImgUri = "www.images.com/image13.png",
                Description = "Description 13",
                Price = 213.0m
            },
            new()
            {
                Id = 14,
                Name = "Mock Product 14", 
                ImgUri = "www.images.com/image14.png",
                Description = "Description 14",
                Price = 214.0m
            },
            new()
            {
                Id = 15,
                Name = "Mock Product 15", 
                ImgUri = "www.images.com/image15.png",
                Description = "Description 15",
                Price = 215.0m
            }
        };
}