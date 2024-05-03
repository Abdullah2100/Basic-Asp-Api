using FackData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FackBuisness
{
    public class clsFackBuisness
    {
        enum enMode { add, update }
        private enMode mode { get; set; }
        public int? id { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public bool? isDeleted { get; set; } = false;


        public clsFackBuisness()
        {
            this.id = null;
            this.name = string.Empty;
            this.job = string.Empty;
            this.isDeleted = null;
            this.mode = enMode.add;
        }


        private clsFackBuisness(enMode mode, int? id, string name, string job, bool? isDeleted)
        {
            this.mode = mode;
            if (id != null)
                this.id = id;
            this.name = name;
            this.job = job;
            if (isDeleted != null)
                this.isDeleted = isDeleted;
        }

        public static List<clsFackBuisness> getFacks()
        {
            try
            {
                return clsFackData.getFacks()
                     .AsEnumerable()
                     .Select(data => new clsFackBuisness(enMode.update, (int)data["fackID"], (string)data["name"], (string)data["job"], (bool)data["isDeleted"]))
                     .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static clsFackBuisness findFackByID(int id)
        {

            string name = "";
            string job = "";
            bool isDeleted = false;
            try
            {

                if (clsFackData.findFack(id, ref name, ref job, ref isDeleted))
                {
                    return new clsFackBuisness(enMode.update, id, name, job, isDeleted);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool _add()
        {
            try
            {
                this.id = clsFackData.createFack(name, job);
                return (this.id != 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool _update()
        {
            try
            {

                return clsFackData.updateFack(id ?? 0, name, job, isDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public clsFackBuisness save()
        {
            try
            {
                switch (mode)
                {
                    case enMode.update:
                        {
                            if (_update())
                                return this;
                        }
                        return null;

                    case enMode.add:
                        {
                            if (_add())
                                return this;
                        }
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }


        public static bool isExistByID(int id)
        {
            try
            {
                return clsFackData.isFackExistById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool deleteFack(int id)
        {
            try
            {
                return clsFackData.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
