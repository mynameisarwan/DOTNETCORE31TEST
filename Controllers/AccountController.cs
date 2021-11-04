using KlinikAPI.DTOS;
using KlinikAPI.Interfaces;
using KlinikAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Controllers
{
   
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;

        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //Api/Account/Login
        [HttpPost("login")]
        public IActionResult Login(LoginRequstDTO loginReq) 
        {
            var user = uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

            if(user == null)
            {
                return Unauthorized();

            }

            return Ok(User);
        }
    }
}
