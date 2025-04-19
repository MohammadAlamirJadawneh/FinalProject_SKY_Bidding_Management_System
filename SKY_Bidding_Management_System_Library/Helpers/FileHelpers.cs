using Microsoft.AspNetCore.Http;



namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class FileHelpers
    {
        public static async Task<byte[]> ConvertToBytesAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
