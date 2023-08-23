using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using server.Data;
using server.Dto;
using server.Model;
using server.service;
using server.Views;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("SearchUsers")]
        public async Task<List<User>> SearchUsers()
        {
            try
            {
                return await _userService.SearchUsers();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("SearchUserById")]
        public async Task<UserView> SearchUserById([FromQuery] int id)
        {
            try
            {
                return await _userService.SearchUserById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]
        public async Task<string> NewUser([FromBody] UserDTO dto)
        {
            try
            {
                return await _userService.NewUser(dto);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public async Task<string> PatchUser([FromBody] User dto)
        {
            try
            {
                return await _userService.PatchUser(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        public async Task<string> DeleteUser([FromQuery] int id)
        {
            try
            {
                return await _userService.DeleteUser(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}