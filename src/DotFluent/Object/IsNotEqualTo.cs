namespace DotFluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether two object instances are not considered equal.
        /// </summary>
        /// <param name="obj">The first object to compare.</param>
        /// <param name="value">The second object to compare.</param>
        /// <param name="reference">Specifies whether to check for reference equality.</param>
        /// <returns>true if the objects are not null and not considered equal; otherwise, false.</returns>
        public static bool IsNotEqualTo(this object obj, object value, bool reference = false)
            => reference ? !ReferenceEquals(obj, value) : !Equals(obj, value);

        #endregion
    }
}
