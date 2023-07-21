﻿using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Commands;
using ElectroTrading.Application.UseCase.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserAddCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            try
            {
                var result = await _mediator.Send(new UserDeleteCommand(Id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
