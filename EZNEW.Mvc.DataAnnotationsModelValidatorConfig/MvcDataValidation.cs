using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZNEW.Mvc.DataAnnotationsModelValidatorConfig
{
    public static class MvcDataValidation
    {
        public static void AddCustomDataAnnotationsModelValidatorProvider(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }
            IOptions<MvcOptions> mvcOptions = serviceProvider.GetService(typeof(IOptions<MvcOptions>)) as IOptions<MvcOptions>;
            IOptions<MvcViewOptions> viewOptions = serviceProvider.GetService(typeof(IOptions<MvcViewOptions>)) as IOptions<MvcViewOptions>;
            mvcOptions.Value.ModelValidatorProviders.Add(new CustomDataAnnotationsModelValidatorProvider(serviceProvider));
            viewOptions.Value.ClientModelValidatorProviders.Add(new CustomDataAnnotationsClientModelValidatorProvider(serviceProvider));
        }
    }
}
