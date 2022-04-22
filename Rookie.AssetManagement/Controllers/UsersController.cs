using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Constants;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.Validators;

namespace Rookie.AssetManagement.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<PagedResponseModel<UserDto>>> GetUsers(
            [FromQuery] UserQueryCriteriaDto userCriteriaDto,
            CancellationToken cancellationToken)
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var userid = Int32.Parse(claimsDictionary[UserClaims.Id]);

            var userResponses = await _userService.GetByPageAsync(
                                            userCriteriaDto,
                                            cancellationToken,
                                            userid);
            return Ok(userResponses);
        }

        [HttpGet("id")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _userService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Not found user with id: " + id);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] UserCreateDto userCreateDto)
        {
            var validationResult = new UserDtoValidator().Validate(userCreateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            else
            {
                var result = await _userService.RegisterUser(userCreateDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<UserDto>> UpdateUser(
            [FromRoute] int id,
            [FromBody] UserCreateDto userRequest)
        {
            var validationResult = new UserDtoValidator().Validate(userRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var updatedUser = await _userService.UpdateAsync(id, userRequest);

            return Ok(updatedUser);
        }

    }
}