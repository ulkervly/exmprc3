using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Exceptions.FeatureException
{
    public class FeatureNotFoundException:Exception
    {
        public string PropertyName { get; set; }
        public FeatureNotFoundException()
        {
        }

        public FeatureNotFoundException(string? message) : base(message)
        {
        }

        public FeatureNotFoundException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
