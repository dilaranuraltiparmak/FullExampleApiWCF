using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyApi.Sample01.DAL.Interfaces;
using MyApi.Sample01.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.MyFilters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductDAL _dal;
        public NotFoundFilter(IProductDAL dal)
        {
            _dal = dal;
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var pro = _dal.Get(a => a.ProductID == id);
            if (pro != null)
            {
                //db de ID var .
                next();
            }
            else
            {
                //id yok 
                ErrorDTO error = new ErrorDTO();
                error.HttpStatusID = 400;
                error.Errors.Add($" {id} nolu Ürün bilgisi DB de yoktur..");
                context.Result =new NotFoundObjectResult(error) ;
            }

            return base.OnActionExecutionAsync(context, next);
        }

    }
}
