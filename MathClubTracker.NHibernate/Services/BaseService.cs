using System;
using System.Reflection;

namespace MathClubTracker.NHibernate.Services
{
    public abstract class BaseService
    {
        public void CheckNull(string propertyName, Type baseObject, object o, ServiceResult result)
        {
            if (o == null || (o.GetType()==typeof(string)) && String.IsNullOrEmpty((string)o))
            {
                PropertyInfo prop = baseObject.GetProperty(propertyName);
                var val = GetPropertyAttributes(prop, "DisplayName");
                result.Errors.Add(String.Format("{0} cannot be null.", val));
            }
        }


        public void Validate(object o, ServiceResult result)
        {

        }




        public static object GetPropertyAttributes(PropertyInfo prop, string attributeName)
        {
            // look for an attribute that takes one constructor argument
            foreach (CustomAttributeData attribData in prop.GetCustomAttributesData())
            {
                string typeName = attribData.Constructor.DeclaringType.Name;
                if (attribData.ConstructorArguments.Count == 1 &&
                    (typeName == attributeName || typeName == attributeName + "Attribute"))
                {
                    return attribData.ConstructorArguments[0].Value;
                }
            }
            return null;
        }
    }
}
