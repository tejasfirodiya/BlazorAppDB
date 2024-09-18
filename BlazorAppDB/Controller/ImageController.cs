using BlazorAppDB.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppDB.Controller;

[Route("api/[controller]")]
[ApiController]
public class ImageController(ImageDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public IActionResult SaveImage([FromForm] int id, [FromForm] IFormFile? imageFile)
    {
        if (id == 0 || imageFile == null || imageFile.Length == 0)
        {
            return BadRequest("Invalid input");
        }

        using var memoryStream = new MemoryStream();
        // Copy the uploaded file's content into the memory stream
        imageFile.CopyTo(memoryStream);

        // Convert the memory stream into a byte array
        var imageBytes = memoryStream.ToArray();

        // Check if the image already exists
        var existingImage = dbContext.ImageCollections.FirstOrDefault(i => i.Id == id);
        if (existingImage != null)
        {
            // Update existing record
            existingImage.Name = imageFile.FileName;
            existingImage.ImageData = imageBytes;
        }
        else
        {
            // Add new record
            var imageRecord = new CustomImageData
            {
                Name = imageFile.FileName,
                ImageData = imageBytes
            };
            dbContext.ImageCollections.Add(imageRecord);
        }

        dbContext.SaveChanges();

        return Ok("Image saved successfully");
    }

    [HttpGet("{id}")]
    public IActionResult LoadImage(int id)
    {
        var image = dbContext.ImageCollections.FirstOrDefault(i => i.Id == id);
        if (image == null)
        {
            return NotFound("Image not found");
        }

        // Convert the byte array to a Base64 string
        var base64Image = Convert.ToBase64String(image.ImageData);
        return Ok(base64Image);
    }
}

//dotnet ef migrations add InitialMigration --context ImageDbContext --project BlazorAppDB --startup-project BlazorAppDB
//dotnet ef database update --context ImageDbContext --project BlazorAppDB --startup-project BlazorAppDB
