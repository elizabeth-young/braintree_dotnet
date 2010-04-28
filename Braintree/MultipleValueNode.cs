#pragma warning disable 1591

using System;
using System.Collections.Generic;

namespace Braintree
{
    public class MultipleValueNode<T> : SearchNode<T> where T : SearchRequest
    {
        protected List<object> AllowedValues;

        public MultipleValueNode(String name, T parent) : base(name, parent)
        {
        }

        public MultipleValueNode(String name, T parent, object[] allowedValues) : base(name, parent)
        {
            AllowedValues = new List<object>(allowedValues);
        }

        public T IncludedIn(params object[] values)
        {
            RaiseErrorOnInvalidValue(values);
            Parent.AddMultipleValueCriteria(Name, new SearchCriteria(values));
            return Parent;
        }

        public T Is(object value)
        {
            return IncludedIn(value);
        }

        private void RaiseErrorOnInvalidValue(object[] values)
        {
            if (AllowedValues == null) return;

            foreach (object value in values)
            {
                if (!AllowedValues.Contains(value))
                {
                    throw new ArgumentOutOfRangeException(String.Format("The {0} node does not accept {1} as a value.", Name, value));
                }
            }
        }
    }
}
