using CimeqApi.Models;
using CimeqApi.ModelView;
using CimeqApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CimeqApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/clients")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Client>> Index()
        {
            try
            {
                List<Client> clients = ClientService.All();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Client> Create([FromBody] Client model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid model");
                }

                Client newClient = ClientService.Add(model);
                return CreatedAtAction(nameof(Index), new { id = newClient.Id }, newClient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Client> Update(int id, [FromBody] Client model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid model");
                }

                Client updatedClient = ClientService.Update(id, model);
                if (updatedClient == null)
                {
                    return NotFound($"Client with ID {id} not found.");
                }

                return Ok(updatedClient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Client> Show(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid model");
                }

                Client client = ClientService.GetById(id);
                if (client == null)
                {
                    return NotFound($"Client with ID {id} not found.");
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = ClientService.Delete(id);
                if (!result)
                {
                    return NotFound($"Client with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
