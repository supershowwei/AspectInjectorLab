using System;
using AspectInjector.Broker;

namespace AspectInjectorLab
{
    [Aspect(Scope.Global)]
    public class LoggingAspect
    {
        [Advice(Kind.Before, Targets = Target.Method)]
        public void Before1([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments)
        {
            Console.WriteLine("On LoggingAspect Before1");
        }

        [Advice(Kind.Before, Targets = Target.Method)]
        public void Before2([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments)
        {
            Console.WriteLine("On LoggingAspect Before2");
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public void After1([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.ReturnValue)] object returnValue)
        {
            Console.WriteLine("On LoggingAspect After1");
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public void After2([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.ReturnValue)] object returnValue)
        {
            Console.WriteLine("On LoggingAspect After2");
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Around1(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> target)
        {
            Console.WriteLine("On LoggingAspect Around1 Before");

            var result = target(arguments);

            Console.WriteLine("On LoggingAspect Around1 After");

            return result;
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Around2(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> target)
        {
            Console.WriteLine("On LoggingAspect Around2 Before");

            var result = target(arguments);

            Console.WriteLine("On LoggingAspect Around2 After");

            return result;
        }
    }

    [Aspect(Scope.Global)]
    public class MeasurementAspect
    {
        [Advice(Kind.Before, Targets = Target.Method)]
        public void Before1([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments)
        {
            Console.WriteLine("On MeasurementAspect Before1");
        }

        [Advice(Kind.Before, Targets = Target.Method)]
        public void Before2([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments)
        {
            Console.WriteLine("On MeasurementAspect Before2");
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public void After1([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.ReturnValue)] object returnValue)
        {
            Console.WriteLine("On MeasurementAspect After1");
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public void After2([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.ReturnValue)] object returnValue)
        {
            Console.WriteLine("On MeasurementAspect After2");
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Around1(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> target)
        {
            Console.WriteLine("On MeasurementAspect Around1 Before");

            var result = target(arguments);

            Console.WriteLine("On MeasurementAspect Around1 After");

            return result;
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Around2(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> target)
        {
            Console.WriteLine("On MeasurementAspect Around2 Before");

            var result = target(arguments);

            Console.WriteLine("On MeasurementAspect Around2 After");

            return result;
        }
    }

    [Injection(typeof(LoggingAspect))]
    [Injection(typeof(MeasurementAspect))]
    public class LoggingAttribute : Attribute
    {
    }
}