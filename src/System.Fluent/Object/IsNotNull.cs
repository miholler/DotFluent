namespace System.Fluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Determines wheter an object instance is not null.
        /// </summary>
        /// <param name="obj">The object to check for not null.</param>
        /// <returns>true if the object is not null; otherwise, false.</returns>
        public static bool IsNotNull(this object obj)
            => obj != null;

        #endregion
    }
}
