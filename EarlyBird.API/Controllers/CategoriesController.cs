using EarlyBird.API.Utils;
using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.DataAccess.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace EarlyBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase 
    {
        private readonly ICategoriesService categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        [Authorize(Policy = Policies.All)]
        public IActionResult GetAll()
        {
            return Ok(categoriesService.GetAll());
        }

        [HttpGet]
        [Route("{categoryId}")]
        [Authorize(Policy = Policies.All)]
        public IActionResult GetById([FromRoute] int categoryId)
        {
            var category = categoriesService.GetById(categoryId);
            if (category == null)
                return NotFound();
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Add([FromBody] AddCategoryDto addCategoryDto)
        {
            try
            {
                var result = categoriesService.Add(addCategoryDto);
                var path = "/api/categories/" + result.Id;
                return Created(path, result);
            }

            catch(CategoriesService.CategoryAlreadyExistingException){
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("{categoryId}")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Delete([FromRoute] int categoryId)
        {
            try
            {
                return (categoriesService.Delete(categoryId)) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }

            catch(CategoriesService.CategoryNotFoundException){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{categoryId}")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Update([FromRoute] int categoryId, [FromBody] AddCategoryDto addCategoryDto)
        {
            try
            {
                return (categoriesService.Update(categoryId, addCategoryDto)) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(CategoriesService.CategoryNotFoundException){
                return NotFound();
            }
        }
    }
}