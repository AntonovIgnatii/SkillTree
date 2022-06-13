using System;

namespace Templates.Saves
{
    [Serializable]
    public class CustomSerialization
    {
        public Type Type;
        public CustomField[] CustomFields;

        public CustomSerialization()
        {
            
        }

        public CustomSerialization(Type _type, CustomField[] _customFields)
        {
            Type = _type;
            CustomFields = _customFields;
        }
    }
}