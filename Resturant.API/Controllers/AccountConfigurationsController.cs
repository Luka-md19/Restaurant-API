using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Resturant.API.Data;
using Resturant.API.Contract; // Assuming you have an interface IAccountConfigurations similar to IMenuCategories
using Resturant.API.Models.AccountConfiguration;
using Resturant.API.Models.Schema;
using Resturant.API.Data.Schema;
using Resturant.API.Exceptions;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountConfigurationsController : ControllerBase
    {
        private readonly IAccountConfigurations _accountConfigurationsRepository;
        private readonly IMapper _mapper;

        public AccountConfigurationsController(IAccountConfigurations accountConfigurationsRepository, IMapper mapper)
        {
            _accountConfigurationsRepository = accountConfigurationsRepository;
            _mapper = mapper;
        }

        // GET: api/AccountConfigurations
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<RestaurantData>>> GetAccountConfigurations()
        {
            var records = await _accountConfigurationsRepository.GetAllAsync<GetAccountConfigurationDto>();
            return Ok(records);
        }

        // GET: api/AccountConfigurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountConfigurationDto>> GetAccountConfiguration(int id)
        {
            var accountConfigurationDto = await _accountConfigurationsRepository.GetAsync<AccountConfigurationDto>(id);
            return Ok(accountConfigurationDto);
        }

        [HttpGet("schema/{accountId}")]
        public async Task<IActionResult> GetSchemaDetails(int accountId)
        {
            try
            {
                var schemaDetails = await _accountConfigurationsRepository.GetSchemaDetailsAsync(accountId);
                return Ok(schemaDetails);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        // PUT: api/AccountConfigurations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountConfiguration(int id, AccountConfigurationDto accountConfigurationDto)
        {
            if (id != accountConfigurationDto.AccountId)
            {
                return BadRequest();
            }
            try
            {
                await _accountConfigurationsRepository.UpdateAsync(id, accountConfigurationDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountConfigurationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AccountConfigurations
        [HttpPost]
        public async Task<ActionResult<AccountConfiguration>> PostAccountConfiguration(CreateAccountConfigurationDto createAccountConfigurationDto)
        {
            var accountConfigurationDto = await _accountConfigurationsRepository.AddAsync<CreateAccountConfigurationDto, GetAccountConfigurationDto>(createAccountConfigurationDto);

            return CreatedAtAction("GetAccountConfiguration", new { id = accountConfigurationDto.AccountId }, accountConfigurationDto);
        }

        // DELETE: api/AccountConfigurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountConfiguration(int id)
        {
            await _accountConfigurationsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> AccountConfigurationExists(int id)
        {
            return await _accountConfigurationsRepository.Exists(id);
        }
    }
}
