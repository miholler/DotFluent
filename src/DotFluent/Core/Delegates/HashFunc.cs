namespace DotFluent;

/// <summary>
/// Represents the method that serves as a hash function for an object 
/// for hashing algorithms and data structures, such as a hash table.
/// </summary>
/// <typeparam name="T">The type of the object for which to get a hash code.</typeparam>
/// <param name="obj">The object for which to get a hash code.</param>
/// <returns>A hash code for the specified object.</returns>
public delegate int HashFunc<in T>(T obj)
#if NET10_0_OR_GREATER
    where T : allows ref struct;
#else
    ;
#endif