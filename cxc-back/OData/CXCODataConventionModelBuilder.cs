using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;

namespace Cxc.OData
{
    public class CxcODataConventionModelBuilder : ODataConventionModelBuilder
    {
        public ConventionModelBuilder _general;

        public CxcODataConventionModelBuilder()
        {
            //oData Entity Mapping
            _general = new ConventionModelBuilder(this);
        }
    }

    public static class extensions 
    {
        public static void AddODataScoped(this IServiceCollection services) 
        {
            ConventionModelBuilder.AddODataScoped(services);
        }

    } 
}
