using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetTypeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AssetTypeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<AssetType>>> GetListAssetTypes()
        {
            var assetTypes = await _dataContext.AssetTypes.ToListAsync();
            return assetTypes;
        }
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetType>> GetAssetTypeById(int id)
        {
            var assetType = await _dataContext.AssetTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (assetType == null)
            {
                throw new Exception($"Asset typ with id {id} not found!");
            }
            
            return assetType;
        }

        [HttpPost]
        public async Task<ActionResult<AssetType>> PostAssetType(Domain.AssetType assetType)
        {
            var checkAssetType = await _dataContext.AssetTypes
                .FirstOrDefaultAsync(x => x.Description.Trim().ToLower() 
                                          == assetType.Description.Trim().ToLower());
            
            if (checkAssetType != null)
            {
                throw new Exception($"Asset typ with name {assetType.Description} exist on database!");
            }

            _dataContext.AssetTypes.Add(assetType);
            var result = await _dataContext.SaveChangesAsync();

            if (result <= 0 )
            {
                throw new Exception("failed to create new Asset Type ");
            }

            return assetType;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AssetType>> Put(int id, AssetType updateAssetType)
        {
            var assetType = await _dataContext.AssetTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (assetType == null)
            {
                throw new Exception($"Asset typ with id {id} not found!");
            }

            assetType.Description = updateAssetType.Description;
            _dataContext.Update(assetType);
            var result = await _dataContext.SaveChangesAsync();

            if (result<= 0)
            {
                throw new Exception($"failed to updated asset type with id {assetType.Id}");
            }
            
            return assetType;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AssetType>> Delete(int id)
        {
            var assetType = await _dataContext.AssetTypes.FindAsync(id);

            if (assetType == null)
            {
                throw new Exception($"Asset typ with id {id} not found!");
            }

            _dataContext.Remove(assetType);
            
            var result = await _dataContext.SaveChangesAsync();

            if (result<= 0)
            {
                throw new Exception($"Failed to remove asset type with id {assetType.Id}");
            }
            
            return assetType;
        }


    }
}