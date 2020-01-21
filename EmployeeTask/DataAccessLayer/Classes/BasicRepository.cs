using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Classes
{
   public class BasicRepository<T> where T : class
    {
        private readonly EmployeeDBModel employeeDBModel;
        public BasicRepository()
        {
            employeeDBModel = new EmployeeDBModel();
        }
        public void Add(T entity)
        {
            employeeDBModel.Set<T>().Add(entity);
            Commit();
        }
        public void Update(T entity)
        {
            employeeDBModel.Set<T>().AddOrUpdate(entity);
            Commit();
        }
        public void Delete(T entity)
        {
            employeeDBModel.Set<T>().Remove(entity);
            Commit();
        }
        public List<T> GetList()
        {
            var listEntities = employeeDBModel.Set<T>().ToList();
            return listEntities;
        }
        public T FindByID(int id)
        {
            return employeeDBModel.Set<T>().Find(id);
        }
        public void Commit()
        {
            var listEntities = employeeDBModel.SaveChanges();
        }
    }
}
