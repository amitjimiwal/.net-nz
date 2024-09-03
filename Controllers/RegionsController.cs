using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiNZWalks.Models.Domain;
using apiNZWalks.Data;
using apiNZWalks.Models.DTO;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiNZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        private readonly NzWalksDBContext _context;
        public RegionsController(NzWalksDBContext context)
        {   
            this._context = context;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult GetAll()
        {
            //get data from the database
            var regions = _context.Regions.ToList();

            //return the dto instead of the entity from database - good practice
            List<RegionsDTO> regionsDTO = new List<RegionsDTO>();
            foreach (var region in regions)
            {
                regionsDTO.Add(new RegionsDTO
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }
            return Ok(regionsDTO);
        }

        //get region by id 
        //make sure the {variable} name matches the parameter name
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByRegionID([FromRoute] Guid id){
            var region = _context.Regions.Find(id);

            //404 if not found
            if(region == null){
                return NotFound();
            }
            

            //convert the output into DTO
            RegionsDTO  result=new RegionsDTO(){
                Id=region.Id,
                Code=region.Code,
                Name=region.Name,
                RegionImageUrl=region.RegionImageUrl
            };
            
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult createRegion([FromBody] AddRegionDTO data){
            //Convert it into domain model
            var regionModel=new Region(){
                Id=new Guid(),
                Code=data.Code,
                Name=data.Name,
                RegionImageUrl=data.RegionImageUrl
            };

            _context.Regions.Add(regionModel);
            //save the data to the database

            //convert the data back to DTO
            var regionDTO=new RegionsDTO(){
                Id=regionModel.Id,
                Code=regionModel.Code,
                Name=regionModel.Name,
                RegionImageUrl=regionModel.RegionImageUrl
            };
            _context.SaveChanges();

            //createdAtAction use the 201 status code (resource created)
            return CreatedAtAction(nameof(createRegion), new {
                id=regionModel.Id,
            },regionDTO);
        }


        [HttpPatch]
        [Route("{id:Guid}")]
        public IActionResult updateRegion([FromRoute] Guid id,[FromBody] updateRegionDTO updateDto){
             var region = _context.Regions.FirstOrDefault(a => a.Id==id);
            if(region == null){
                return NotFound();
            }
           if(updateDto.Code!=null) region.Code=updateDto.Code;
           if(updateDto.Name!=null) region.Name=updateDto.Name;
           if(updateDto.RegionImageUrl!=null) region.RegionImageUrl=updateDto.RegionImageUrl;
            //update the value
            _context.SaveChanges();

            var regionDTO=new RegionsDTO(){
                Id=region.Id,
                Code=region.Code,
                Name=region.Name,
                RegionImageUrl=region.RegionImageUrl
            };
            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult updateRegion([FromRoute] Guid id){
            var region = _context.Regions.FirstOrDefault(a => a.Id==id);
            if(region == null){
                return NotFound();
            }

            _context.Regions.Remove(region);
            _context.SaveChanges();


            return Ok("Succesfully deleted!1");
        }
    }
}

