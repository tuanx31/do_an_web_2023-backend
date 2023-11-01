using web_api.Reponsitory.Abastract;

namespace web_api.Reponsitory.Implementation
{
    public class FileService : IFileService

    {
        private IWebHostEnvironment environment;

        public FileService(IWebHostEnvironment env)
        {

            this.environment = env;

        }
        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extenstions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" ,".webp"};
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
        public Tuple<int, string[]> SaveMultiImage(IFormFileCollection imageFileCollection)
        {
            try
            {
                string[] listnewFileName = new string[0];

                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var imageFile in imageFileCollection)
                {
                    // Check the allowed extenstions
                    var ext = Path.GetExtension(imageFile.FileName);
                    var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg", ".webp" };
                    //if (!allowedExtensions.Contains(ext))
                    //{
                    //    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    //    return new Tuple<int, string[]>(0, msg);
                    //}
                    string uniqueString = Guid.NewGuid().ToString();
                    // we are trying to create a unique filename here
                    var newFileName = uniqueString + ext;
                    var fileWithPath = Path.Combine(path, newFileName);
                    var stream = new FileStream(fileWithPath, FileMode.Create);
                    imageFile.CopyTo(stream);
                    stream.Close();
                    Array.Resize(ref listnewFileName, listnewFileName.Length + 1);
                    listnewFileName[listnewFileName.Length - 1] = newFileName;

                }
                return new Tuple<int, string[]>(1, listnewFileName);
            }
            catch (Exception ex)
            {
                string[] msg = { "Error has occured" };
                return new Tuple<int, string[]>(0, msg );
            }
        }
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath = this.environment.ContentRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
