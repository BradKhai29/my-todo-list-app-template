namespace Core.Entity.Base;

/// <summary>
///     Base interface for any domain entity that has ID column as primary key.
/// </summary>
/// <typeparam name="TKey">
///     Type of the key used for the table.
/// </typeparam>
public interface IKeyDomainEntity<TKey> : IDomainEntity
{
    public TKey Id { get; set; }
}
