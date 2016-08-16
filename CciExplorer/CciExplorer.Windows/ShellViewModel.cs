namespace TourreauGilles.CciExplorer.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using Microsoft.Cci;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.ViewModel;
    using Microsoft.Win32;

    public class ShellViewModel : NotificationObject
    {
        private readonly ICommand openAssemblyCommand;
        private readonly IEventAggregator eventAggregator;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.openAssemblyCommand = new DelegateCommand(() => this.OpenAssembly());
        }

        public ICommand OpenAssemblyCommand
        {
            get { return this.openAssemblyCommand; }
        }

        public void OpenAssembly()
        {
            OpenFileDialog dialog;

            dialog = new OpenFileDialog();
            dialog.Filter = "Assembly (*.dll, *.exe) | *.dll";

            if (dialog.ShowDialog() == true)
            {
                IAssembly assembly;
                
                assembly = (IAssembly)((CciExplorerApplication)Application.Current).MetaDataReaderHost.LoadUnitFrom(dialog.FileName);

                this.eventAggregator.GetEvent<AssemblyEvent>().Publish(assembly);
            }
        }
    }
}
