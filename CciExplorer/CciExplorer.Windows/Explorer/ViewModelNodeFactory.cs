using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class ViewModelNodeFactory
    {
        public virtual NodeViewModel CreateViewModel(INamedEntity dotNetObject)
        {
            if (dotNetObject is INamespaceDefinition)
            {
                return this.CreateNamespaceNodeViewModel((INamespaceDefinition)dotNetObject);
            }

            if (dotNetObject is ITypeDefinition)
            {
                return this.CreateTypeNodeViewModel((ITypeDefinition)dotNetObject);
            }

            if (dotNetObject is IMethodDefinition)
            {
                IMethodDefinition method;

                method = (IMethodDefinition)dotNetObject;
                if (method.IsConstructor == true)
                {
                    return this.CreateConstructorViewModel(method);
                }
                else
                {
                    return this.CreateMethodNodeViewModel(method);
                }
            }

            if (dotNetObject is IPropertyDefinition)
            {
                return this.CreatePropertyNodeViewModel((IPropertyDefinition)dotNetObject);
            }

            if (dotNetObject is IFieldDefinition)
            {
                return this.CreateFieldNodeViewModel((IFieldDefinition)dotNetObject);
            }

            if (dotNetObject is IEventDefinition)
            {
                return this.CreateEventNodeViewModel((IEventDefinition)dotNetObject);
            }

            throw new NotSupportedException();
        }

        protected virtual NodeViewModel CreateConstructorViewModel(IMethodDefinition method)
        {
            return new ConstructorNodeViewModel(method);
        }

        protected virtual NodeViewModel CreateEventNodeViewModel(IEventDefinition eventDefinition)
        {
            return new EventNodeViewModel(eventDefinition);
        }

        protected virtual NodeViewModel CreateFieldNodeViewModel(IFieldDefinition field)
        {
            return new FieldNodeViewModel(field);
        }

        protected virtual NodeViewModel CreateMethodNodeViewModel(IMethodDefinition method)
        {
            return new MethodNodeViewModel(method);
        }

        protected virtual NodeViewModel CreateNamespaceNodeViewModel(INamespaceDefinition ns)
        {
            return new NamespaceNodeViewModel(ns);
        }

        protected virtual NodeViewModel CreatePropertyNodeViewModel(IPropertyDefinition property)
        {
            return new PropertyNodeViewModel(property);
        }

        protected virtual NodeViewModel CreateTypeNodeViewModel(ITypeDefinition type)
        {
            return new TypeNodeViewModel(type);
        }
    }
}
