namespace Domain.BaseModels
{
    using System;

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
