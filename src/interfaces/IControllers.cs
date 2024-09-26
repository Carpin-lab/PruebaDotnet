using Microsoft.AspNetCore.Mvc;

namespace PruebaDotnet.src.interfaces
{
    public interface IControllers<TEntity>
    {
        public Task<IActionResult> GetById(int id);
        public Task<IActionResult> Get();
        public Task<IActionResult> Add(TEntity entity);

        public Task<IActionResult> Update(int id, TEntity entity);

        public Task<IActionResult> Delete(int id); //NOTE: We don´t gonna delete the data, we just wanna update the status to inactive
    }
}