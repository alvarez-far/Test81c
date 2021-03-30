using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test81b.DAL;
using Test81b.Models;

namespace Test81b.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private DefaultContext db;

        public UsersController(DefaultContext context)
        {
            db = context;
        }

        //CREATE
        [HttpPost]
        public IActionResult createUser(Usuario user)
        {
            try
            {
                db.Add(user);
                db.SaveChanges();
            }
            catch
            {
                // I'll think about a more meaningful error later
                return StatusCode(500);
            }

            return Ok();
        }

        //READ
        [HttpGet]
        public IEnumerable<Usuario> getUsers()
        {
            return db.Usuarios
                .Include(x => x.Departamento)
                .ToArray();
        }

        //UPDATE
        [HttpPut]
        public IActionResult updateUsers(Usuario user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                // I'll think about a more meaningful error later
                return StatusCode(500);
            }

            return Ok();
        }

        //DELETE
        [HttpDelete]
        public IActionResult deleteUser(int userId)
        {
            var user = db.Usuarios.Find(userId);
            if(user == null)
            {
                return NotFound();
            }

            try
            {
                db.Remove(user);
                db.SaveChanges();
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok();
        }



    }
}
