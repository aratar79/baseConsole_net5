using System.Threading.Tasks;
using Models.DTOS;

namespace Services.Interfaces
{
    public interface IModelService
    {
        bool CreateModelDemo(ModelDemoDTO model);
        ModelDemoDTO GetModelDemo(int id);
        Task<ModelDemoDTO> GetModelDemoAsync(int id);
        bool UpdateModelDemo(ModelDemoDTO modelDTO);
        bool DeleteModelDemo(long id);

        long GetLastModelDemo();
    }
}