using CimeqApi.Models;
using CimeqApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CimeqApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/orders")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Order>> Index()
        {
            try
            {
                List<Order> orders = OrderService.All();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid model");
                }

                Order newOrder = OrderService.Add(model);
                return CreatedAtAction(nameof(Index), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Order> Update(int id, [FromBody] Order model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid model");
                }

                Order updatedOrder = OrderService.Update(id, model);
                if (updatedOrder == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Show(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid model");
                }

                Order order = OrderService.GetById(id);
                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                return Ok(order);
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
                bool result = OrderService.Delete(id);
                if (!result)
                {
                    return NotFound($"Order with ID {id} not found.");
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
