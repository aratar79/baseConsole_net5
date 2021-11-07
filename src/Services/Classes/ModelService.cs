using System.Threading.Tasks;
using Models.DTOS;
using Orm.DataBase;
using Services.Interfaces;
using System.Linq;
using Models.Domain;

namespace Services.Classes
{
    public class ModelService : IModelService
    {
        private readonly ApplicationDBContext _context;

        public ModelService(ApplicationDBContext context)
        {
            _context = context;
        }
        public ModelDemoDTO GetModelDemo(int id)
        {
            var result = _context.ModelDemos.FirstOrDefault(t => t.Id == id);
            return new ModelDemoDTO
            {
                Id = result.Id,
                NameModel = result.NameModel,
                Description = result.Description
            };
        }
        
        public long GetLastModelDemo()
        {
            return _context.ModelDemos.Max(m => m.Id);
        }

        public async Task<ModelDemoDTO> GetModelDemoAsync(int id)
        {
            return await Task<ModelDemoDTO>.Factory.StartNew(() =>
            {
                var result = _context.ModelDemos.FirstOrDefault(t => t.Id == id);
                return new ModelDemoDTO
                {
                    Id = result.Id,
                    NameModel = result.NameModel,
                    Description = result.Description
                };
            });
        }

        public bool CreateModelDemo(ModelDemoDTO modelDTO)
        {
            var model = new ModelDemo {
                NameModel = modelDTO.NameModel,
                Description = modelDTO.Description
            };
            _context.Add(model);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateModelDemo(ModelDemoDTO modelDTO)
        {
            var model = new ModelDemo {
                Id = modelDTO.Id,
                NameModel = modelDTO.NameModel,
                Description = modelDTO.Description
            };
            _context.Update(model);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteModelDemo(long id)
        {
            var result = 0;
            var model = _context.ModelDemos.FirstOrDefault(m => m.Id == id);
            if(model is not null)
            {
                _context.ModelDemos.Remove(model);
                result = _context.SaveChanges();
            }
            return result > 0;
        }

    }
}