using Microsoft.AspNetCore.Routing;

namespace Moviefactory.Presentation.Endpoints;

public interface IEndpointGroup
{
    static abstract IEndpointRouteBuilder RegisterEndpointGroup(IEndpointRouteBuilder app);
}