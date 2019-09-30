namespace DotFluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Determines wheter an object instance is not null.
        /// </summary>
        /// <param name="source">The object to check for not null.</param>
        /// <returns>true if the object is not null; otherwise, false.</returns>
        public static bool IsNotNull(this object source)
            => source != null;

        #endregion
    }
}
