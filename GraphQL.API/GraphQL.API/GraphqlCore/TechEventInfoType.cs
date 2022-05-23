namespace GraphQL.API.GraphqlCore
{
    public class TechEventInfoType : ObjectType<TechEventInfo>
    {
        protected override void Configure(IObjectTypeDescriptor<TechEventInfo> descriptor)
        {
            descriptor.BindFields(BindingBehavior.Explicit);

            descriptor.Field(f => f.EventId).Description("Id wydarzenia");
            descriptor.Field(f => f.EventName).Description("Nazwa wydarzenia");
            descriptor.Field(f => f.EventDate).Description("Czas rozpoczęcia");
            descriptor.Field(f => f.EventParticipants).Description("Lista uczestników");

            descriptor.Ignore(f => f.EventParticipants);
        }
    }
}
