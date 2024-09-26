namespace PruebaDotnet.src.interfaces
{
    public interface IServices<TEntity>
    {
        public Task<IEnumerable<TEntity>> Get();
        public Task<TEntity> GetById(int id);
        public Task<TEntity> Add(TEntity entity);

        public Task<TEntity> Update(int id, TEntity entity);

        public void Delete(int id); //NOTE: We don´t gonna delete the data, we just wanna update the status to inactive

    }
}