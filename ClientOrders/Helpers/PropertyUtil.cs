﻿using System.Reflection;


namespace ClientOrders.Helpers
{
    public static class PropertyUtil
    {
        /// <summary>
        /// Extension method for copying property values from one object to another. 
        /// Property must have the same type and name in order to be copied.
        /// </summary>
        /// <typeparam name="TargetType">Target type to which values will be copied.</typeparam>
        /// <typeparam name="SourceType">Source type to which values will be copied.</typeparam>
        /// <param name="targetObject">Target object to which values will be copied.</param>
        /// <param name="sourceObject">Source object to which values will be copied.</param>
        /// <returns>Target object.</returns>
        public static T CopyProperties<T, T2>(this T targetObject, T2 sourceObject)
        {
            targetObject.GetTypeProperties().Where(p => p.CanWrite).ToList()
                .ForEach(property => FindAndReplaceProperty(targetObject, sourceObject, property));
                
            return targetObject;
        }

        /// <summary>
        /// Method which finds and replaces corresponding properties
        /// </summary>
        private static void FindAndReplaceProperty<T, T2>(T targetObject, T2 sourceObject, PropertyInfo property)
        {
            if (sourceObject.GetTypeProperties().Any(prop => CheckIfPropertyExistInSource(prop, property)))
            {
                property.SetValue(targetObject, sourceObject.GetPropertyValue(property.Name), default);
            }
        }

        /// <summary>
        /// Simple methods to get properties
        /// </summary>
        private static IEnumerable<PropertyInfo> GetTypeProperties<T2>(this T2 sourceObject) 
        {
            return sourceObject.GetType().GetProperties();
        }

        /// <summary>
        /// Methods which checks if given property exists in source as well
        /// </summary>        
        private static bool CheckIfPropertyExistInSource(PropertyInfo prop, PropertyInfo property)
        {
            return string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);
        }

        /// <summary>
        /// Methods which gets given property value
        /// </summary>  
        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }       
    }
}
