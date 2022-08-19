using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastStart.Entities;
using FastStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastStart.Controllers
{
    [Route("api/users")]
    public class UsersControllers : ControllerBase
    {
        private readonly UsersDbContext _dbContext;
        private readonly IMapper _mapper;
        public UsersControllers(UsersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateUsers([FromBody] CreateUsersDTO dto)
        {
            var users = _mapper.Map<Users>(dto);
            _dbContext.Users.Add(users);
            _dbContext.SaveChanges();

            return Created($"/api/users/{users.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsersDTO>> GetAll()
        {
            var users = _dbContext
                .Users
                .Include(u => u.Roles)
                .ToList();

            var usersDTOs = _mapper.Map<List<UsersDTO>>(users);

            return Ok(usersDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UsersDTO>> Get([FromRoute] int id)
        {
            var users = _dbContext
                .Users
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Id == id);
            if (users is null)
            {
                return NotFound();
            }
            var usersDTO = _mapper.Map<UsersDTO>(users);
            return Ok(usersDTO);
        }
    }
}
