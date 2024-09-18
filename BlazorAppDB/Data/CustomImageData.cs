using System.ComponentModel.DataAnnotations;

namespace BlazorAppDB.Data
{
    public class CustomImageData
    {
        public int Id { get; set; }
        [StringLength(50)] public string Name { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;
    }
}
