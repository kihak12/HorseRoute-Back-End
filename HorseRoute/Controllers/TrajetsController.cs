using HorseRoute.Exceptions;
using HorseRoute.Models;
using HorseRoute.Models.Trajets;
using HorseRoute.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Controllers
{
    [ApiController]
    [Route("api/trajets")]
    public class TrajetsController : ControllerBase
    {
        private readonly ITrajetService _trajetService;

        public TrajetsController(ITrajetService trajetService)
        {
            _trajetService = trajetService;
        }

        [HttpGet()]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<TrajetDto>>> GetTrajets()
        {
            try
            {
                return Ok(await _trajetService.GetTrajets());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{trajetId}", Name = "getTrajet")]
        public async Task<ActionResult<TrajetDetails>> GetTrajet(Guid trajetId)
        {
            try
            {
                return Ok(await _trajetService.GetTrajetDetail(trajetId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId}/user", Name = "getUserTrajets")]
        public async Task<ActionResult<IEnumerable<TrajetDto>>> GetUserTrajets(Guid userId)
        {
            try
            {
                return Ok(await _trajetService.GetUserTrajets(userId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<TrajetDto>>> SearchTrajets(TrajetForSearchDto trajets)
        {
            try
            {
                return Ok(await _trajetService.SearchTrajets(trajets));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("create", Name = "CreateTrajet")]
        public ActionResult<TrajetDetailsDto> CreateTrajet(TrajetForCreationDto trajet)
        {
            try
            {
                var trajetDetailsToReturn = _trajetService.CreateTrajet(trajet);
                return CreatedAtRoute("GetTrajet",
                    new { TrajetId = trajetDetailsToReturn.TrajetId },
                    trajetDetailsToReturn);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("{trajetId}/addClient", Name = "AddClientToTrajet")]
        public async Task<ActionResult> AddPassagerToTrajet(TrajetPassagerDto trajetClient, Guid trajetId)
        {
            try
            {
                trajetClient.TrajetId = trajetId;
                await _trajetService.AddPassagerToTrajet(trajetClient);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{trajetId}/removeClient", Name = "RemoveClientToTrajet")]
        public ActionResult RemovePassagerFromTrajet(TrajetPassagerDto trajetClient, Guid trajetId)
        {
            try
            {
                trajetClient.TrajetId = trajetId;
                _trajetService.RemovePassagerFromTrajet(trajetClient);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{trajetId}/Delete", Name = "DeleteTrajet")]
        public async Task<ActionResult> DeleteTrajet(Guid trajetId)
        {
            try
            {
                await _trajetService.DeleteTrajet(trajetId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
