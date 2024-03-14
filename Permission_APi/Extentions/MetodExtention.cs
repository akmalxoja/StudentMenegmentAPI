namespace VehicleManagementAPI.Extentions
{
    public class MetodExtention
    {
        private readonly IWebHostEnvironment _env;
        public MetodExtention(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }


        public async Task<string> AddPictureAndGetPath(IFormFile file)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Guid.NewGuid() + file.FileName);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }
            return path;


        }
    }
}
