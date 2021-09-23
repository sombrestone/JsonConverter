using System;
using System.Collections.Generic;
using System.Text;

namespace CustomJsonConverter
{
    class JsonNameAttribute: Attribute
    {
        public string Name { get; }

        public JsonNameAttribute(string name)
        {
            Name = name;
        }
    }
}
