using play.catlog.service.Dto;
using play.catlog.service.Entities;

namespace play.catlog.service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }

        
    }
}