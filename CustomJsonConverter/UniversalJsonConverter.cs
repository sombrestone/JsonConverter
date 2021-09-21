using System;
using System.Reflection;

namespace CustomJsonConverter
{
    class UniversalJsonConverter
    {
        public string Serialize(object item)
        {
            try
            {
                string result = serialize(item);
                return result.Remove(result.Length-1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        string serialize(object obj, int nesting=0)
        {
            bool isArray = obj.GetType().IsArray;

            string result = new string('\t', nesting)+ (isArray ? "[\n": "{\n");
            if (isArray) foreach (var item in (Array)obj)
                {
                    result += new string('\t', nesting + 1) +
                        (isObject(item.GetType()) ? 
                        "\n" + serialize(item, nesting + 1)
                        :
                        (isString(item.GetType()) ? $"\"{item}\"" : $"{item}") + ",\n");
                }
            else
            {
                var props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    result += new string('\t', nesting + 1) + ($"\"{prop.Name}\" : " +
                        (isObject(prop.PropertyType) ?
                            "\n" + serialize(prop.GetValue(obj), nesting + 1)
                            :
                            (isString(prop.PropertyType) ? $"\"{prop.GetValue(obj)}\"" : $"{ prop.GetValue(obj)}") + ",\n"));
                }
            }
            return result+= new string('\t', nesting) + (isArray ? "],\n" : "},\n");
        }

        private static bool isObject(Type prop) => ((!prop.IsValueType) && (!isString(prop)));

        private static bool isString(Type prop) => (prop.Name == "String");
    }
}
