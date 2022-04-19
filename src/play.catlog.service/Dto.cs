using System;
using System.ComponentModel.DataAnnotations;

namespace play.catlog.service.Dto
{
    public record ItemDto(Guid Id, string Name, string Description, decimal price, DateTimeOffset CreatedDate);
    public record CreateItemdto([Required]string Name, string Description, [Range(0,1000)]decimal price);
     public record UpdateItemdto([Required]string Name, string Description, [Range(0,1000)]decimal price);

}