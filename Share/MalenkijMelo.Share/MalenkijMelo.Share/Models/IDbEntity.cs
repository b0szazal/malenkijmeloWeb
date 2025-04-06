namespace MalenkijMelo.Share.Models
{
    public interface IDbEntity<TEntity> where TEntity : class, new()
    {
        string Id { get; set; }
        bool HasId => Id != string.Empty;
        public string GetDbSetName()
        {
            return string.Concat(new TEntity().GetType(), 's');
        }
    }
}
