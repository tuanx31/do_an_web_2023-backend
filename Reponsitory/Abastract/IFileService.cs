namespace web_api.Reponsitory.Abastract
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public Tuple<int, string[]> SaveMultiImage(IFormFileCollection imageFileCollection);
        public bool DeleteImage(string imageFileName);
    }
}
