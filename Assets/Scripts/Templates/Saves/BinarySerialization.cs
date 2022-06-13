using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

namespace Templates.Saves
{
    public static class BinarySerialization
    {
        public static void Save<T>(T value, string name) where T : class
        {
            CustomSerialization customSerialization = GetSerializedFields(value);
            using (FileStream fs = new FileStream(FilePath(name), FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(fs, customSerialization);
            }
        }
 
        public static void Load<T>(ref T defaultValue, string name) where T :class
        {
            if (File.Exists(FilePath(name)) == false)
            {
                return;
            }

            CustomSerialization customSerialization;
            
            using (FileStream fs = new FileStream(FilePath(name), FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                
                customSerialization = (CustomSerialization)formatter.Deserialize(fs);
            }

            SetSerializedFields(defaultValue, customSerialization);
        }

        public static void Delete(string name)
        {
            var path = FilePath(name);
            if (File.Exists(path) == false)
            {
                return;
            }

            File.Delete(path);
        }
        
        private static CustomSerialization GetSerializedFields<T>(T value)
        {
            var fields = value.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            var serializedFields = new List<CustomField>();

            foreach (var field in fields)
            {
                var allNonSerializedAttributes = field.GetCustomAttributes<NonSerializedAttribute>();
                if (allNonSerializedAttributes.Any())
                {
                    continue;
                }
                
                serializedFields.Add(new CustomField(field.FieldType, field.Name, field.GetValue(value)));
            }

            return new CustomSerialization(value.GetType(), serializedFields.ToArray());
        }

        private static void SetSerializedFields<T>(T value, CustomSerialization customSerialization)
        {
            var fields = value.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).ToDictionary(f => f.Name, f => f);

            foreach (var customField in customSerialization.CustomFields)
            {
                if (fields.TryGetValue(customField.Name, out var findField))
                {
                    var allNonSerializedAttributes = findField.GetCustomAttributes<NonSerializedAttribute>();
                    if (allNonSerializedAttributes.Any())
                    {
                        continue;
                    }
                    
                    findField.SetValue(value, customField.Object);
                }
            }
        }
        
        private static string FilePath(string name)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Application.persistentDataPath);
            stringBuilder.Append("/");
            stringBuilder.Append(name);
            return stringBuilder.ToString();
        }
    }
}