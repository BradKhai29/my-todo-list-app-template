namespace Core.Entity.Base;

/// <summary>
///     Base interface for any entity class included in this
///     project need to extend from. This interface can be considered
///     as a marker interface to indicate a class is a domain entity.
/// </summary>
/// <remarks>
///     Domain entity class is the <c>CORE</c> class to decide the structure
///     of the table in the database, ensure that all defined properties must
///     be the same as table columns.
///
///     These classes will be used later for reflection.
/// </remarks>
public interface IDomainEntity
{
}
