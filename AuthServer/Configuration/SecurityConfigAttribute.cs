using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Configuration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SecureConfigAttribute : Attribute
    {
        public SecureConfigAttribute(string fieldname, bool isReplace = false)
        {
            this.FieldName = fieldname;
            this.IsReplace = isReplace;
        }

        public string FieldName { get; }
        public bool IsReplace { get; }
    }
}
