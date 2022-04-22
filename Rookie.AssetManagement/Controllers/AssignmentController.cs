using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.Validators;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<PagedResponseModel<AssignmentDTO>>> GetAssignments(
        [FromQuery] AssignmentQueryCriteria assignmentCriteria,
        CancellationToken cancellationToken)
        {
            var userid = GetUserId();

            var responses = await _assignmentService.GetByPageAsync(
                                            assignmentCriteria,
                                            cancellationToken,
                                            userid);
            return Ok(responses);
        }

        [HttpGet("home")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public async Task<ActionResult<PagedResponseModel<AssignmentDTO>>> GetAssignmentsForHomePage(
        [FromQuery] AssignmentQueryCriteria assignmentCriteria,
        CancellationToken cancellationToken)
        {
            var userid = GetUserId();

            var responses = await _assignmentService.GetByPageForHomeAsync(
                                            assignmentCriteria,
                                            cancellationToken,
                                            userid);
            return Ok(responses);
        }
        
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] AssignmentCreateDTO assignmentCreateDTO)
        {
            var validationResult = new AssignmentDtoValidator().Validate(assignmentCreateDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            else
            {
                var userid = GetUserId();
                var result = await _assignmentService.CreateAssignment(assignmentCreateDTO, userid);
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
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _assignmentService.DeleteAssignment(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("respond")]
        [Authorize]
        public async Task<ActionResult<AssignmentDTO>> RespondToAssignment([FromBody] AssignmentResponseDTO dto)
        {
            var validationResult = new AssignmentResponseDTOValidator().Validate(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            else
            {
                var userid = GetUserId();
                var result = await _assignmentService.RespondToAssigment(dto, userid);
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
        public async Task<ActionResult<AssignmentDTO>> UpdateAssignment(
            [FromRoute] int id,
            [FromBody] AssignmentCreateDTO assignmentRequest)
        {
            var validationResult = new AssignmentDtoValidator().Validate(assignmentRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var userid = GetUserId();
            var updatedAssignment = await _assignmentService.UpdateAsync(id, assignmentRequest, userid);

            return Ok(updatedAssignment);
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
