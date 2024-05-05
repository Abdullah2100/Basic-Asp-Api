namespace FackApi.Dto
{
    public class clsUpdateFackDto
    {
        public int? id { get; set; } = null;

        public string name { get; set; } = "";

        public string job { get; set; } = "";

        public bool? isDeleted { get; set; } = false;

        public IFormFile image { get; set; }


    }
}
