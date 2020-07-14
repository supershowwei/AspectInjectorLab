using System;
using System.ComponentModel;
using AspectInjector.Broker;

namespace AspectInjectorLab.Wpf
{
    [AttributeUsage(AttributeTargets.Class)]
    [Injection(typeof(NotifyAspectAttribute))]
    [Aspect(Scope.PerInstance)]
    [Mixin(typeof(INotifyPropertyChanged))]
    public class NotifyAspectAttribute : Attribute, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Advice(Kind.After, Targets = Target.Public | Target.Setter)]
        public void AfterSetter([Argument(Source.Instance)] object sender, [Argument(Source.Name)] string propertyName)
        {
            this.PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }

    [NotifyAspect]
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.MyText = "Hello World";
        }

        public string MyText { get; set; }
    }
}