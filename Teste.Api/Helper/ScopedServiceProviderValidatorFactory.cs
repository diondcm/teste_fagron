using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Api.Helper
{
    public class ScopedServiceProviderValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ScopedServiceProviderValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [DebuggerStepThrough]
        public override IValidator CreateInstance(Type validatorType)
        {
            try
            {
                return _serviceProvider.GetService(validatorType) as IValidator;
            }
            catch (InvalidOperationException)
            {
                using var scope = _serviceProvider.CreateScope();
                return scope.ServiceProvider.GetService(validatorType) as IValidator;
            }
        }
    }
}
