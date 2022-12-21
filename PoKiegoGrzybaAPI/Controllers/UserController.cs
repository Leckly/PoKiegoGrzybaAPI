﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using PoKiegoGrzybaAPI.Data;
using PoKiegoGrzybaAPI.Data.Helpers;
using PoKiegoGrzybaAPI.Data.Req;
using PoKiegoGrzybaAPI.Models;

namespace PoKiegoGrzybaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PoKiegoGrzybaDbContext _context;
        public ILogger<UserController> _logger;

        public UserController(PoKiegoGrzybaDbContext context,ILogger<UserController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterData userRegisterData)
        {
            try
            {
                var check = await _context.MushroomHunter.AnyAsync(x => x.Login == userRegisterData.Login || x.EmailAdress == userRegisterData.Email);
                if (!check)
                {
                    var user = new MushroomHunter()
                    {
                        Login = userRegisterData.Login,
                        EmailAdress = userRegisterData.Email,
                        Avatar = userRegisterData.Avatar,
                        Points = 0,
                        Password = SecretHasher.Hash(userRegisterData.Password)
                    };
                    await _context.MushroomHunter.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return Conflict("Istnieje użytkownik o podanym loginie lub emailu");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] UserLogInData userLogInData)
        {
            try
            {
                if (userLogInData.Login == null)
                {
                    var userData = await _context.MushroomHunter.FirstOrDefaultAsync(x => x.EmailAdress == userLogInData.Email);
                    if (userData != null)
                    {
                        if(SecretHasher.Verify(userLogInData.Password, userData.Password))
                            return Ok();
                        else
                        {
                            return ValidationProblem("Bad data");
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var userData = await _context.MushroomHunter.FirstOrDefaultAsync(x => x.EmailAdress == userLogInData.Email);
                    if (userData != null)
                    {

                        if (SecretHasher.Verify(userLogInData.Password, userData.Password))
                            return Ok();
                        else
                        {
                            return ValidationProblem("Bad data");
                        }
                    }
                    else
                    {
                        return NotFound();
                    }

                }
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
    }
}