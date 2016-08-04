using System.Linq;
using Gvhs.Web.DataContracts;
using Gvhs.Web.Infrastructures.Models;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Gvhs.Web.Infrastructures.Controllers
{
    /// <summary>
    /// Restful Api
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    [Route("Weixin/api/[controller]")]
    public class ApiControllerBase<T> : AuthorControllerBase where T : class, IEntity
    {
        protected readonly DbContext DbContext;

        public ApiControllerBase(IBllServiceProvider serviceProvider) : base(serviceProvider)
        {
            DbContext = serviceProvider.DbContext;
        }

        [HttpGet]
        public virtual IActionResult Get(PaginateParamter paramter)
        {
            var query = DbContext.Set<T>()
                .Take(paramter.length)
                .Skip(paramter.start);
            return Ok(query.ToList());
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChangesAsync();
            return Created("url", null);
        }

        [HttpPut("{id:int}")]
        public virtual IActionResult Put(int id, [FromBody] T entity)
        {
            var oldEntity = DbContext.Set<T>().FirstOrDefault(t => t.Id == id);
            if(oldEntity == null ) return HttpNotFound();
            DbContext.Entry(oldEntity).State = EntityState.Deleted;
            DbContext.Attach(entity);
            DbContext.Update(entity);
            DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            var entity = DbContext.Set<T>().FirstOrDefault(t => t.Id == id);
            if (entity == null) return HttpNotFound();
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
