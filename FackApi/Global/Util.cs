namespace FackApi.Global
{
    public class Util
    {

        private static string _imagesPath = "Images";
        public static string hostUrl = "https://localhost:7055/";
        private static string getFileExtention(string file)
        {
            FileInfo _fileInfo = new FileInfo(file);
            return _fileInfo.Extension;
        }

        public static bool isExistFile(string file)
        {
            try
            {
                return File.Exists(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
                return false;
            }
        }

        private static bool _createDirectory()
        {
            try
            {
                if (!Directory.Exists(path: _imagesPath))
                {
                    Directory.CreateDirectory(path: _imagesPath);
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
                return false;

            }
        }
        private static string _generateName() => Guid.NewGuid().ToString();
        public static string saveFile(IFormFile file)
        {
            try
            {
                if (!_createDirectory())
                {
                    return "";
                }
                string imageFullName = _imagesPath + "\\" + _generateName() + getFileExtention(file.FileName);

                var path = Path.Combine(_imagesPath, imageFullName);
                var stream = new MemoryStream();
                file.CopyTo(stream);
                File.WriteAllBytes(imageFullName, stream.ToArray());
                return imageFullName;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
                return "";
            }

        }


        public static bool deletedFile(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
                return false;
            }

        }

    }
}
