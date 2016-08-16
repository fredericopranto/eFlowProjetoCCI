using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CodeModel;
using Microsoft.Practices.Prism.Commands;

namespace TourreauGilles.CciExplorer.Windows.Source
{
    internal sealed class ParagraphSourceWriter : SourceWriterBase
    {
        private readonly Paragraph paragraph;
        private readonly SourceModule module;

        public ParagraphSourceWriter(SourceModule module, Paragraph paragraph)
        {
            this.module = module;
            this.paragraph = paragraph;
        }

        private void Write(Inline element)
        {
            if (this.IsNewLine == true)
            {
                StringBuilder space;

                space = new StringBuilder();
                for (int i = 0; i < this.CurrentIndentation; i++)
                {
                    space.Append(" ");
                }

                this.paragraph.Inlines.Add(space.ToString());
            }

            this.paragraph.Inlines.Add(element);
        }

        private void Write(Run element, string format, params object[] arguments)
        {
            if (arguments.Length > 0)
            {
                format = string.Format(format, arguments);
            }

            element.Text = format;

            this.Write(element);
        }

        protected override void WriteCore(string format, params object[] arguments)
        {
            this.Write(new Run(), format, arguments);
        }

        protected override void NewLineCore()
        {
            this.paragraph.Inlines.Add(new LineBreak());
        }

        public void WriteWithStyle(string styleKey, string format, params object[] arguments)
        {
            Run element;

            element = new Run();
            element.Style = CciExplorerApplication.Current.Resources[styleKey] as Style;

            this.Write(element, format, arguments);
        }

        protected override void WriteCharCore(char character)
        {
            this.WriteWithStyle("String", "\'{0}\'", character);
        }

        protected override void WriteStringCore(string str)
        {
            this.WriteWithStyle("String", "\"{0}\"", str);
        }

        protected override void WriteKeywordCore(string keyworkToken)
        {
            this.WriteWithStyle("Keyword", keyworkToken);
        }

        protected override void WriteReferenceCore(IReference reference, string format, params object[] arguments)
        {
            Hyperlink hyperlink;

            hyperlink = new Hyperlink(new Run(string.Format(format, arguments)));
            hyperlink.Style = CciExplorerApplication.Current.Resources["Reference"] as Style;
            hyperlink.Command = new DelegateCommand(() => this.GotoDefinition(reference));

            this.Write(hyperlink);
        }

        private void GotoDefinition(IReference reference)
        {
            this.module.EventAggregator.GetEvent<CurrentObjectEvent>().Publish(reference.GetDefinition());
        }
    }
}
