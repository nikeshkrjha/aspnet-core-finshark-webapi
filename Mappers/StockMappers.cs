using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using Npgsql.Replication;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {
            return new StockDTO
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                Purchase = stock.Purchase,
                Industry = stock.Industry,
                Comments = stock.Comments.Select(c => c.ToCommentDTO()).ToList()
            };
        }

        public static Stock ToStockFromStockRequestDTO(this CreateStockRequestDTO createStockRequestDTO)
        {
            return new Stock
            {
                Symbol = createStockRequestDTO.Symbol,
                CompanyName = createStockRequestDTO.CompanyName,
                LastDiv = createStockRequestDTO.LastDiv,
                MarketCap = createStockRequestDTO.MarketCap,
                Purchase = createStockRequestDTO.Purchase,
                Industry = createStockRequestDTO.Industry
            };
        }
    }
}