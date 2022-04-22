using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.Validators;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IAssetCategoryService _assetCategoryService;
        public AssetController(IAssetService assetService, IAssetCategoryService assetCategoryService)
        {
            _assetService = assetService;
            _assetCategoryService = assetCategoryService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<PagedResponseModel<AssetDTO>>> GetAssets(
        [FromQuery] AssetQueryCriteria assetCriteria,
        CancellationToken cancellationToken)
        {
            var userid = GetUserId();

            var responses = await _assetService.GetByPageAsync(
                                            assetCriteria,
                                            cancellationToken,
                                            userid);
            return Ok(responses);
        }

        [HttpGet("categories")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<List<AssetCategoryDTO>>> GetAssetCategories()
        {
            var list = await _assetCategoryService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        // [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] AssetCreateDTO assetCreateDto)
        {
            var validationResult = new AssetDtoValidator().Validate(assetCreateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            else
            {
                var userid = GetUserId();
                var result = await _assetService.CreateAsset(assetCreateDto, userid);
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
        public async Task<ActionResult<AssetDTO>> Update([FromRoute] int id,
                                                        [FromBody] AssetUpdateDTO assetUpdateDTO)
        {
            Ensure.Any.IsNotNull(assetUpdateDTO, nameof(assetUpdateDTO));

            var validationResult = new AssetUpdateDtoValidator().Validate(assetUpdateDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            else
            {
                var updatedAsset = await _assetService.UpdateAsset(id, assetUpdateDTO);
                if (updatedAsset != null)
                {
                    return Ok(updatedAsset);
                }
                else
                {
                    return BadRequest(updatedAsset);
                }
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userid = GetUserId();
            var result = await _assetService.DeleteAsset(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        #region Private Method
        private int GetUserId()
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var userid = Int32.Parse(claimsDictionary[UserClaims.Id]);

            return userid;
        }
        #endregion
    }
}
