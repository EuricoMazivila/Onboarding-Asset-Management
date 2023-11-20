using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetTypeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AssetType> Get()
        {
            var assetType = new List<AssetType>
            {
                new AssetType
                {
                    Id = 1,
                    Name = "Test"
                },
                new AssetType
                {
                    Id = 2,
                    Name = "Test 2"
                }
            };
            return assetType;
        }


        [HttpGet("{id}")]
        public ActionResult<AssetType> GetById(int id)
        {
            var assetTypes = new List<AssetType>
            {
                new AssetType
                {
                    Id = 1,
                    Name = "Test"
                },
                new AssetType
                {
                    Id = 2,
                    Name = "Test 2"
                }
            };

            var assetType = assetTypes.FirstOrDefault(x => x.Id == id);

            if (assetType == null)
            {
                throw new Exception($"Asset typ with id {id} not found!");
            }
            
            return assetType;
        }

        [HttpPost]
        public ActionResult<AssetType> Post(AssetType assetType)
        {
            var assetTypes = new List<AssetType>
            {
                new AssetType
                {
                    Id = 1,
                    Name = "Test"
                },
                new AssetType
                {
                    Id = 2,
                    Name = "Test 2"
                }
            };

            var checkAssetType = assetTypes.FirstOrDefault(x => x.Name.Trim().ToLower() 
                                                                == assetType.Name.Trim().ToLower());
            
            if (checkAssetType != null)
            {
                throw new Exception($"Asset typ with name {assetType.Name} exist on database!");
            }
            
            assetTypes.Add(assetType);
            
            return assetType;
        }

        [HttpPut("{id}")]
        public ActionResult<AssetType> Put(int id, AssetType updateAssetType)
        {
            var assetTypes = new List<AssetType>
            {
                new AssetType
                {
                    Id = 1,
                    Name = "Test"
                },
                new AssetType
                {
                    Id = 2,
                    Name = "Test 2"
                }
            };

            var assetType = assetTypes.FirstOrDefault(x => x.Id == id);

            if (assetType == null)
            {
                throw new Exception($"Asset typ with id {id} not found!");
            }

            assetType.Name = updateAssetType.Name;
            
            return assetType;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<AssetType> Delete(int id)
        {
            var assetTypes = new List<AssetType>
            {
                new AssetType
                {
                    Id = 1,
                    Name = "Test"
                },
                new AssetType
                {
                    Id = 2,
                    Name = "Test 2"
                }
            };

            var assetType = assetTypes.FirstOrDefault(x => x.Id == id);

            if (assetType == null)
            {
                throw new Exception($"Asset typ with id {id} not found!");
            }

            assetTypes.Remove(assetType);

            return assetType;
        }


    }

    public class AssetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}