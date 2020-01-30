using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace FuzzDotNet
{
    public class Adapter
    {
        // TODO For now, we'll just require that exact type matches are required for each generator. Don't get into inheritance
        private static readonly IDictionary<Type, IGenerator> DefaultGenerators = new Dictionary<Type, IGenerator> {
        };

        public void RunTests(Type testClass) {
            // How much of this can be static?

            var constructor = testClass.GetConstructor(new Type[] {});

            var instance = constructor.Invoke(new object[] {});

            foreach (var method in testClass.GetMethods()) {
                var attribute = method.GetCustomAttribute<FuzzTestAttribute>();
                if (attribute == null) continue;

                var argumentGenerators = method.GetParameters().Select(GetGenerator);

                // We'll have to get more sophisticated with how random numbers are generated for better reproducibility
                // Maybe use one random instance which seeds each generator?
                var random = new Random();
                var arguments = argumentGenerators.Select(g => g.Generate(random));
                method.Invoke(instance, arguments.ToArray());
            }
        }

        private static IGenerator GetGenerator(ParameterInfo parameter)
        {
            var generatorAttribute = parameter.GetCustomAttribute<GeneratorAttribute>();

            // Don't do any fancy class based lookup
            return generatorAttribute?.Generator ?? DefaultGenerators[parameter.ParameterType];
        }
    }
}
