using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using play.catlog.service.Dto;
using play.catlog.service.Entities;
using play.catlog.service.Repository;

namespace play.catlog.service.controllers{

  [ApiController]
  [Route("Items")]
    public class ItemController: ControllerBase
    {
       private readonly IItemRepository itemRepository;

       public ItemController(IItemRepository itemRepo)
       {
         itemRepository = itemRepo;
       }
         [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
          var items = (await itemRepository.getAllItems())
                      .Select(item => item.AsDto());
            return items;
        }


      [HttpGet("{id}")]
      //[Route("id")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
        var item = await itemRepository.GetAsync(id);
        if(item == null)
        {
          return NotFound();
        }
        return item.AsDto();
        }

        [HttpPost]
        public async  Task<ActionResult<ItemDto>> PostAsync(CreateItemdto createitemDto)
        {
         var item = new Item
            {
              Name = createitemDto.Name,
              Description = createitemDto.Description,
              Price = createitemDto.price,
              CreatedDate = DateTimeOffset.UtcNow
            };
           await itemRepository.CreateAsync(item);
          
         
          return CreatedAtAction(nameof(GetByIdAsync), new{id =item.Id}, item);
        }

      [HttpPut("id")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemdto updateitemDto)
        {
          var existingItem = await itemRepository.GetAsync(id);
          if(existingItem == null)
          {
            return NotFound();
          }
           existingItem.Name = updateitemDto.Name;
           existingItem.Description = updateitemDto.Description;
           existingItem.Price = updateitemDto.price;
           await itemRepository.UpdateAsync(existingItem);
        
          return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
          var item = await itemRepository.GetAsync(id);
        if(item == null)
        {
          return NotFound();
        }
         await itemRepository.RemoveAsync(item.Id);
          return NoContent();
        }
    }
}