using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class ExplorerModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;
        private readonly IEventAggregator eventAggregator;

        public ExplorerModule(IRegionViewRegistry registry, IEventAggregator eventAggregator)
        {
            this.regionViewRegistry = registry;
            this.eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            this.regionViewRegistry.RegisterViewWithRegion("ExplorerRegion", () => new ExplorerView() { DataContext = new ExplorerViewModel(this.eventAggregator) });
        }
    }
}
