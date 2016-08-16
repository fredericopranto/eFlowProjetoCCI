using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Cci;
using Microsoft.Practices.Prism.ViewModel;
using TourreauGilles.CciExplorer.CSharp;
using Microsoft.Practices.Prism.Events;

namespace TourreauGilles.CciExplorer.Windows.Source
{
    internal class SourceViewModel : NotificationObject
    {
        private FlowDocument document;
        private IDictionary<IDefinition, FlowDocument> cache;

        private readonly SourceModule module;
        
        public SourceViewModel(SourceModule module)
        {
            this.module = module;
            this.cache = new Dictionary<IDefinition, FlowDocument>();

            module.EventAggregator.GetEvent<CurrentObjectEvent>().Subscribe(definition => this.ChangeDocument(definition));
        }

        public FlowDocument Document
        {
            get
            {
                return this.document;
            }

            set
            {
                if (this.document != value)
                {
                    this.document = value;
                    this.RaisePropertyChanged(() => this.Document);
                }
            }
        }

        private void ChangeDocument(IDefinition definition)
        {
            FlowDocument document;

            if (this.cache.TryGetValue(definition, out document) == false)
            {
                Paragraph paragraph;
                CSharpSourceGenerator generator;

                paragraph = new Paragraph();

                generator = new CSharpSourceGenerator(
                    CciExplorerApplication.Current.MetaDataReaderHost,
                    new CSharpSourceWriter(new ParagraphSourceWriter(this.module, paragraph)));

                definition.Dispatch(generator);
                
                document = new FlowDocument();
                document.FontFamily = new FontFamily("Consolas");
                document.Blocks.Add(paragraph);

                this.cache.Add(definition, document);
            }

            this.Document = document;
        }
    }
}
