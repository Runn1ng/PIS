using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.Controllers
{
    class FileController
    {
        public static int SaveFile(string path)
        {
            using (DbContext db = new DbContext())
            {
                var file = new File();
                file.Path = path;
                db.Files.Add(file);
                db.SaveChanges();
                return file.Id;
            }
        }

        public static void DeleteFile(int? file_id)
        {
            using(DbContext db = new DbContext())
            {
                var file = db.Files.FirstOrDefault(x => x.Id == file_id);
                db.Files.Remove(file);
                db.SaveChanges();
            }
        }
    }
}
