using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Repo
{
    public class Teacher_Repo<T> : ITeacher_Repo<T> where T : class
    {
        private readonly Teacher_Repo_Context context;

        private DbSet<T> teachers;

        public Teacher_Repo(Teacher_Repo_Context context1)
        {
            context = context1;
            teachers = context.Set<T>();
        }

        public IEnumerable<T> GetAllTeachers()
        {
            return teachers.ToList();
        }

        public T? GetTeacher(int? Id)
        {
            return teachers.Find(Id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                teachers.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                teachers.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                teachers.Remove(entity);
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public T InsertWithReturn(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                teachers.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public string DeleteWithReturn(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                teachers.Remove(entity);
                context.SaveChanges();
                return "Delete Successfully";
            }
        }

        public string UpdateDetailTeacher(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                context.SaveChanges();
                return "Update Successfully";
            }
        }
    }
}
