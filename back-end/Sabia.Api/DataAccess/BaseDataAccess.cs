using Microsoft.EntityFrameworkCore;
using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class BaseDataAccess<T> where T : BaseModel
    {
        public SabiaContext Context { get; set; }

        public BaseDataAccess(SabiaContext ctx)
        {
            Context = ctx;
        }


        public virtual T GetById(long id)
        {            
            return Context.Set<T>().Find(id);
        }

        public virtual void Save(T model)
        {
            DbSet<T> set = Context.Set<T>();

            if (model.Id == 0)
            {
                set.Add(model);
            }
            else
            {
                var attached = set.Local.FirstOrDefault(x => x.Id == model.Id);
                if (attached != null)
                {
                    //Context.Detach(attached);
                }
                set.Attach(model);
                Context.Entry(model).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }


        public virtual void Delete(T model)
        {
            Context.Set<T>().Remove(model);
        }

        public IEnumerable<T> List()
        {
            return Context.Set<T>();
        }


    }
}
