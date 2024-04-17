using Microsoft.AspNetCore.Builder;
using Moviefactory.Presentation.Endpoints;
using System.Reflection;

namespace Moviefactory.Presentation.Registration;

public static class EndpointRegistration
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        var endpointTypes = GetEndpointTypes();

        foreach (var endpointType in endpointTypes)
        {
            var endpointGroup = GetEndpointGroupType(endpointType);
            var endpointRegisterMethod = endpointType.GetMethod(nameof(IEndpoint.RegisterEndpoint))!;
            var endpointInstance = Activator.CreateInstance(endpointType)!;

            if (endpointGroup is null)
            {
                endpointRegisterMethod.Invoke(endpointInstance, [app]);
                continue;
            }

            var endpointGroupRegisterMethod = endpointGroup.GetMethod(nameof(IEndpointGroup.RegisterEndpointGroup))!;
            var endpointGroupInstance = (IEndpointGroup)Activator.CreateInstance(endpointGroup)!;

            var routeGroupBuilder = endpointGroupRegisterMethod.Invoke(endpointGroupInstance, [app]);
            endpointRegisterMethod.Invoke(endpointInstance, [routeGroupBuilder]);
        }

        return app;
    }

    private static Type? GetEndpointGroupType(TypeInfo endpoint)
    {
        return endpoint
            .GetInterfaces()
            .First(x => x.IsGenericType && x.Name.Contains(nameof(IEndpoint)))
            .GetGenericArguments()
            .FirstOrDefault(x => x.IsAssignableTo(typeof(IEndpointGroup)));
    }

    private static TypeInfo[] GetEndpointTypes()
    {
        return typeof(EndpointRegistration)
            .Assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
            .ToArray();
    }
}