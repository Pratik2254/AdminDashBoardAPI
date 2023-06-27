﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminDashBoard.Models;

namespace AdminDashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly DashboardContext _context;

        public ShoesController(DashboardContext context)
        {
            _context = context;
        }

        // GET: api/Shoes
        [HttpGet("GetAllShoes")]
        public IActionResult GetShoes()
        {
           var shoes= _context.Shoes.ToList();
            return Ok(shoes);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var shoes = _context.Shoes.FirstOrDefault(o=>o.ShoesId==id);
            return Ok(shoes);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var shoes = _context.Shoes.FirstOrDefault(o => o.ShoesId == id);
            if (shoes != null)
            {
                _context.Remove(shoes);
                _context.SaveChanges();
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost("Create")]
        public IActionResult Create(Shoe _shoes)
        {
            var shoes = _context.Shoes.FirstOrDefault(o => o.ShoesId == _shoes.ShoesId);
            if (shoes != null)
            {
                shoes.Name = _shoes.Name;
                shoes.Price = _shoes.Price;
                shoes.Quantity = _shoes.Quantity;
                shoes.AddedDate = _shoes.AddedDate;
                shoes.AddedBy = _shoes.AddedBy;
                

            }
            else
            {
                _context.Shoes.Add(_shoes);
                _context.SaveChanges();
                
            }
            return Ok(true);

            
            
        }

        [HttpPut("Update")]
        public IActionResult Put(Shoe _shoes)
        {
            _context.Shoes.Update(_shoes);
            _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
