using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using    GettingStartedWebAspBooks.Data.Repositories;
using Microsoft.CodeAnalysis.CSharp;
using  GettingStartedWebAspBooks.ViewModels.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace GettingStartedWebAspBooks.Controllers
{
    //[Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var count = await _usersRepository.CountAsync();
            return Ok(new {count});
        }

        [HttpGet("{email:minlength(6)}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _usersRepository.GetByEmail(email);

            return Ok(new
            {
                user = Mapper.Map<UsersViewModel>(user)
            });
        }



        [HttpGet]
        public async Task<IActionResult> GetByEmailQuery([FromQuery] string email)
        {
            var user = await _usersRepository.GetByEmail(email);

            return Ok(new
            {
                user = Mapper.Map<UsersViewModel>(user)
            });
        }

        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UsersEditViewModel model)
        {
            var result = await _usersRepository.AddPolicyToUser(model.Email, "RolePermissionsChange");

            return Ok(result);
        }

    }
}