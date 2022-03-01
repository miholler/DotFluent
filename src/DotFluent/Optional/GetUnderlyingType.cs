using System;
using System.Linq;

namespace DotFluent.Optional
{
    public static partial class Option
    {
        #region Methods

        /// <summary>
        /// Returns the underlying type argument of the specified option type.
        /// </summary>
        /// <param name="optionType">The type that describes a closed generic option type.</param>
        /// <returns>
        /// The type argument of the optionType parameter, if the optionType parameter
        /// is a closed generic option type; otherwise, null.
        /// </returns>
        public static Type? GetUnderlyingType(Type optionType)
        {
            optionType.ThrowIfNull();
            
            if (optionType.IsGenericType && !optionType.IsGenericTypeDefinition)
            {
                var genericType = optionType.GetGenericTypeDefinition();
                if (typeof(Option<>).IsAssignableFrom(genericType))
                    return optionType.GetGenericArguments().FirstOrDefault();
            }
            return null;
        }

        #endregion
    }
}
