namespace ALM.Screens.Mission
{
    public interface IEntity
    {
        IEntityId Id { get; set; }
    }

    public interface IEntityId
    {
        int Value { get; }
    }
}