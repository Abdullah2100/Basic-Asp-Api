﻿namespace FackApi.Dto
{
    public class clsFackDto
    {

        public string name { get; set; } = "";

        public string job { get; set; } = "";

        public bool? isDeleted { get; set; } = false;

        public IFormFile image { get; set; }

        public bool isHasNullValue()
        {
            return string.IsNullOrEmpty(name) || string.IsNullOrEmpty(job);
        }
    }
}
