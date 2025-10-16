namespace Core.Entity.Base;

/// <summary>
///     Base abstract class for any domain entity that has their
///     corresponding table with primary key used <see langword="long"/> datatype.
/// </summary>
public abstract class LongKeyDomainEntity : IKeyDomainEntity<long>
{
    public long Id { get; set; }
}
