namespace Domain.BaseModels
{
    using System;

    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
