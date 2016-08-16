using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace TourreauGilles.CciExplorer.Windows.Source
{
    internal class SourceModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;
        private readonly IEventAggregator eventAggregator;

        public SourceModule(IRegionViewRegistry registry, IEventAggregator eventAggregator)
        {
            this.regionViewRegistry = registry;
            this.eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            this.regionViewRegistry.RegisterViewWithRegion("ContentRegion", () => new SourceView() { DataContext = new SourceViewModel(this) });
        }

        public IEventAggregator EventAggregator
        {
            get { return this.eventAggregator; }
        }
    }
}
