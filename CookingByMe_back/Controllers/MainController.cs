using Microsoft.AspNetCore.Mvc;

namespace CookingByMe_back.Controllers
{
    public abstract class MainController : ControllerBase
    {
        protected void AddImage(IFormFile file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
