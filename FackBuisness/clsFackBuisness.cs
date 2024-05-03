using FackData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FackBuisness
{
    public class clsFackBuisness
    {
        enum enMode { add, update }
        private enMode mode { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public bool isDeleted { get; set; }
        public clsFackBuisness()
        {
            this.id = 0;
            this.name = string.Empty;
            this.job = string.Empty;
            this.isDeleted = false;
            this.mode = enMode.add;
        }

        private clsFackBuisness(enMode mode, int id, string name, string job, bool isDeleted)
        {
            this.mode = mode;
            this.id = id;
            this.name = name;
            this.job = job;
            this.isDeleted = isDeleted;
        }

        public static async Task<List<clsFackBuisness>> getFacks()
        {
            try
            {
                return clsFackData.getFacks()
                     .Result
                     .AsEnumerable()
                     .Select(data => new clsFackBuisness(enMode.update, (int)data["id"], (string)data["name"], (string)data["job"], (bool)data["isDelete"]))
                     .ToList();
            }
            catch (AggregateException ex)
            {
                throw ex;
            }

        }
    }
}
