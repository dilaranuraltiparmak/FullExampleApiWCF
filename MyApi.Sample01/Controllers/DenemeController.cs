using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Sample01.DAL.Interfaces;
using MyApi.Sample01.DTO;
using MyApi.Sample01.Models.Entities;
using MyApi.Sample01.MyFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.Controllers
{
    /// <summary>
    /// REST : => 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        //action verb ?
        private  readonly IProductDAL _dal;
        private readonly IMapper _mapper;
        public DenemeController(IProductDAL dal,IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

       [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var deger = await _dal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(deger));
        }

        //[HttpGet("husam")]
        //public async Task<IActionResult> GetAllAsync02()
        //{
        //    var deger = await _dal.GetAllAsync();
        //    return Ok(_mapper.Map<IEnumerable<ProductDTO>>(deger));
        //}

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dal.Delete(new Models.Entities.Product() { ProductID = id });
                return Ok();
            }
            catch (Exception ex)
            {
                //log
                return new StatusCodeResult(401);
            }        
        }

        [HttpPost]
        [Route("~/api/addPro")]
        public IActionResult Post([FromBody]ProductDTO dto)
        {
            try
            {
                _dal.Add(_mapper.Map<Product>(dto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {             
            }
            return new StatusCodeResult(400);
        }
    }
}
