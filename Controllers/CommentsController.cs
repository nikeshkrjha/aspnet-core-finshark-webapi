using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IStockRepository _stockRepo;

        public CommentsController(ICommentRepository repository, IStockRepository stockRepository)
        {
            _repository = repository;
            _stockRepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _repository.GetAllCommentsAsync();
            var commentDTOs = comments.Select(stock => stock.ToCommentDTO());
            return Ok(commentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _repository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var commentDTO = comment.ToCommentDTO();
            return Ok(commentDTO);
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> CreateComment(int stockId, CreateCommentDTO createCommentDTO)
        {
            var stockExists = await _stockRepo.StockExists(stockId);
            if (!stockExists)
            {
                return BadRequest();
            }
            var comment = createCommentDTO.ToCommentFromCreateCommentDTO(stockId);
            await _repository.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { Id = comment.Id }, comment.ToCommentDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _repository.DeleteCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequestDTO commentRequestDTO)
        {
            var updatedComment = await _repository.UpdateCommentAsync(id, commentRequestDTO);
            if (updatedComment == null)
            {
                return BadRequest();
            }

            return Ok(updatedComment.ToCommentDTO());
        }
    }
}