using System.Collections.Generic;
using System.Linq;
using System.Data;
using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class NivelDA
    {
        //--------------------------------- TREE VIEW REAL
        public IEnumerable<TB_TREE> GetLvl()
        {
            var ana = new List<TB_TREE>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_TREE> query = db.TB_TREE;

                query = query.Where(item => item.parentId == 0 && item.proyectoId == 0);

                query = query.OrderBy(p => p.id);

                return query.ToList();
            }
        }


        public IEnumerable<TB_TREE> getLevelsToDeleteFromProject(int projectId)
        {
            var ana = new List<TB_TREE>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_TREE> query = db.TB_TREE;

                query = query.Where(item => item.proyectoId == projectId);

                query = query.OrderBy(p => p.id);

                return query.ToList();
            }
        }

        public IEnumerable<TB_TREE> GetLvlFromPyUsuario(int projectId)
        {
            var ana = new List<TB_TREE>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_TREE> query = db.TB_TREE;

                query = query.Where(item => item.parentId == 0 && item.proyectoId == projectId);

                query = query.OrderBy(p => p.id);

                return query.ToList();
            }
        }        


        public IEnumerable<TB_TREE> GetSubLvl(int pId)
        {
            var ana = new List<TB_TREE>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_TREE> query = db.TB_TREE;

                if (pId > 0)
                {
                    query = query.Where(item => item.parentId == pId);
                }

                query = query.OrderBy(p => p.id);

                return query.ToList();
            }
        }


        public int InserNewLevel(TB_TREE lvl)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(lvl);
                result = db.SaveChanges();
            }
            return result;
        }


        public int UpdateLvlName(int Id, string nombre)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var lvl = db.TB_TREE.Where(item => item.id == Id).FirstOrDefault();
                lvl.title = nombre;

                result = db.SaveChanges();
            }
            return result;
        }

        public int UpdateLvlParent(int id, int newParentID)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var lvl = db.TB_TREE.Where(item => item.id == id).FirstOrDefault();
                lvl.parentId = newParentID;

                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteLevel(int Id)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                var file = db.TB_TREE.Where(item => item.id == Id).SingleOrDefault();
                db.TB_TREE.Remove(file);
                result = db.SaveChanges();
            }
            return result;
        }



        //--------------------------------- TREE VIEW ANTERIOR
        public IEnumerable<TB_NIVEL> GetMaster()
        {
            var ana = new List<TB_NIVEL>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_NIVEL> query = db.TB_NIVEL;

                query = query.Where(item => item.ParentNivelID == 0 && item.ProyectoId == 0);

                query = query.OrderBy(p => p.NivelID);

                return query.ToList();
            }
        }

        public IEnumerable<TB_NIVEL> GetSubNiveles(int pId)
        {
            var ana = new List<TB_NIVEL>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_NIVEL> query = db.TB_NIVEL;

                if (pId > 0)
                {
                    query = query.Where(item => item.ParentNivelID == pId);
                }

                query = query.OrderBy(p => p.NivelID);

                return query.ToList();
            }
        }




        



    }
}
