﻿namespace HouseRentingSystem.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ContainerType == typeof(Decimal) || context.Metadata.ModelType == typeof(Decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
