using System;
using AspectInjector.Broker;

namespace AspectInjectorLab
{
    public interface ILoggable
    {
        void Before(string name, object[] arguments);

        void After(string name, object[] arguments, object returnValue);

        object Around(string name, object[] arguments, Func<object[], object> target);
    }

    [Aspect(Scope.Global)]
    [Injection(typeof(LoggableAttribute))]
    public class LoggableAttribute : Attribute, ILoggable
    {
        [Advice(Kind.Before, Targets = Target.Private)]
        public void Before([Argument(Source.Name)]string name, [Argument(Source.Arguments)]object[] arguments)
        {
            Console.WriteLine("On Before");
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public void After([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.ReturnValue)] object returnValue)
        {
            Console.WriteLine("On After");
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Around(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> target)
        {
            Console.WriteLine("On Around Before");

            var result = target(arguments);

            Console.WriteLine("On Around After");

            return result;
        }
    }
}