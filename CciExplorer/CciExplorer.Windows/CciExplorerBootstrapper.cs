using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Events;

namespace TourreauGilles.CciExplorer.Windows
{
    internal class CciExplorerBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new ShellView() { DataContext = new ShellViewModel(this.Container.TryResolve<IEventAggregator>()) };
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            CciExplorerApplication.Current.MainWindow = (Window)this.Shell;
            CciExplorerApplication.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog;
            
            moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(Source.SourceModule));
            moduleCatalog.AddModule(typeof(Explorer.ExplorerModule));
        }
    }
}
