using System;

namespace Templates.Saves
{
    [Serializable]
    public struct CustomField
    {
        public Type Type;
        public string Name;
        public object Object;
        
        public CustomField(Type _type, string _name, object _object)
        {
            Type = _type;
            Name = _name;
            Object = _object;
        }

        public override string ToString()
        {
            return $"{Name};{Type};{Object}";
        }
    }
}