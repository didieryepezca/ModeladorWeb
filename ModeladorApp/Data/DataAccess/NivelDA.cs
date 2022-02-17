using System.Collections.Generic;
using System.Linq;
using System.Data;
using ModeladorApp.Models.Entities;
using System;

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


        public int UpdateLvlTitleAndDescription(int Id, string title, string description)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var lvl = db.TB_TREE.Where(item => item.id == Id).FirstOrDefault();
                lvl.title = title;
                lvl.descripcion = description;

                result = db.SaveChanges();
            }
            return result;
        }

        public int UpdateLvlDescriptionFromChilds(int vId, string description)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                var lvl = db.TB_TREE.Where(item => item.id == vId).FirstOrDefault();                
                lvl.descripcion = description;

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

        public TB_TREE GetLevelToDuplicate(int Id)
        {
            var result = new TB_TREE();
            {
                using (var db = new ApplicationDbContext())
                {
                    result = db.TB_TREE.Where(item => item.id == Id).FirstOrDefault();
                }
            }
            return result;
        }


        //--------------------> comprobar si el ya existe en la BD antes de ingresar un duplicado de la microbase.
        public TB_TREE getInfoLevelBeforeDuplicate(string titulo, int pyId, int parentId)
        {
            var result = new TB_TREE();
            {
                using (var db = new ApplicationDbContext())
                {
                    result = db.TB_TREE.Where(item => item.title == titulo && 
                                                      item.proyectoId == pyId && 
                                                      item.parentId == parentId).FirstOrDefault();
                }
            }
            return result;
        }



    }
}
