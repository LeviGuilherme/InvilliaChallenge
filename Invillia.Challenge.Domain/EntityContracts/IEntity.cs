namespace Invillia.Challenge.Domain.EntityContracts
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
