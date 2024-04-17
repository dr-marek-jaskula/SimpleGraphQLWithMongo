using Microsoft.AspNetCore.Routing;

namespace Moviefactory.Presentation.Endpoints;

public interface IEndpoint<TEndpointGroup> : IEndpoint
    where TEndpointGroup : class, IEndpointGroup, new()
{
}

public interface IEndpoint
{
    void RegisterEndpoint(IEndpointRouteBuilder app);
}
