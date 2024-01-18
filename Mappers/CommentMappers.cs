using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Title = comment.Title,
                Description = comment.Description,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
            };
        }

        public static Comment ToCommentFromCreateCommentDTO(this CreateCommentDTO createCommentDTO, int stockId)
        {
            return new Comment
            {
                Title = createCommentDTO.Title,
                Description = createCommentDTO.Description,
                StockId = stockId
            };
        }
    }
}