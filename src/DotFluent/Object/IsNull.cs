namespace DotFluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether an object instance is null.
        /// </summary>
        /// <param name="source">The object to check for null.</param>
        /// <returns>true if the object is null; otherwise, false.</returns>
        public static bool IsNull(this object source)
            => source == null;

        #endregion
    }
}
