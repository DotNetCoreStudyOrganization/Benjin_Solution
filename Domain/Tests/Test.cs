namespace Domain.Tests
{
    using Domain.BaseModels;

    public class Test : Entity, IAggregateRoot
    {
        public string Title { get; set; }
    }
}
