namespace System.Fluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether two object instances are considered equal.
        /// </summary>
        /// <param name="obj">The first object to compare.</param>
        /// <param name="value">The second object to compare.</param>
        /// <param name="reference">Specifies whether to check for reference equality.</param>
        /// <returns>true if the objects are considered equal or if both are null; otherwise, false.</returns>
        public static bool IsEqualTo(this object obj, object value, bool reference = false)
            => reference ? ReferenceEquals(obj, value) : Equals(obj, value);

        #endregion
    }
}
