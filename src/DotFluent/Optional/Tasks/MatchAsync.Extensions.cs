using DotFluent.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTaskExtensions
    {
        #region Methods

        /// <summary>
        /// Asynchronously performs a specified action if an option is a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="none">An action to perform if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
        public static Task MatchAsync<TSource>(this Task<Option<TSource>> source, Action none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            none.ThrowIfNull();

            return source.Then(x => x.Match(none), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function if an option is a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="none">A function to invoke if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
        public static Task MatchAsync<TSource>(this Task<Option<TSource>> source, Func<Task> none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            none.ThrowIfNull();

            return source.Then(x => x.MatchAsync(none, cancellationToken), cancellationToken);
        }

        /// <summary>
        /// Asynchronously performs a specified action if an option is a 'Some' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">An action to perform if a value is present.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
        public static Task MatchAsync<TSource>(this Task<Option<TSource>> source, Action<TSource> some, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();

            return source.Then(x => x.Match(some), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function if an option is a 'Some' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">A function to invoke if a value is present.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
        public static Task MatchAsync<TSource>(this Task<Option<TSource>> source, Func<TSource, Task> some, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();

            return source.Then(x => x.MatchAsync(some, cancellationToken), cancellationToken);
        }

        /// <summary>
        /// Asynchronously performs a specified action based on whether an option
        /// is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">An action to perform if a value is present.</param>
        /// <param name="none">An action to perform if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
        public static Task MatchAsync<TSource>(this Task<Option<TSource>> source, Action<TSource> some, Action none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();
            none.ThrowIfNull();

            return source.Then(x => x.Match(some, none), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function based on whether an option
        /// is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">A function to invoke if a value is present.</param>
        /// <param name="none">A function to invoke if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
        public static Task MatchAsync<TSource>(this Task<Option<TSource>> source, Func<TSource, Task> some, Func<Task> none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();
            none.ThrowIfNull();

            return source.Then(x => x.MatchAsync(some, none, cancellationToken), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function, or returns a specified alternative value
        /// based on whether an option is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the result value.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">A function to invoke if a value is present.</param>
        /// <param name="none">The value to return if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
        /// the result of the invoked function if a value is present; otherwise the specified alternative value.
        /// </returns>
        public static Task<TResult> MatchAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, TResult> some, TResult none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();

            return source.Then(x => x.Match(some, none), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function, or returns a specified alternative value
        /// based on whether an option is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the result value.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">A function to invoke if a value is present.</param>
        /// <param name="none">The value to return if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
        /// the result of the invoked function if a value is present; otherwise the specified alternative value.
        /// </returns>
        public static Task<TResult> MatchAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, Task<TResult>> some, TResult none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();

            return source.Then(x => x.MatchAsync(some, none, cancellationToken), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function based on whether an option
        /// is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the result value.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">A function to invoke if a value is present.</param>
        /// <param name="none">A function to invoke if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
        /// the result of the invoked function.
        /// </returns>
        public static Task<TResult> MatchAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, TResult> some, Func<TResult> none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();
            none.ThrowIfNull();

            return source.Then(x => x.Match(some, none), cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a specified function based on whether an option
        /// is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the result value.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="some">A function to invoke if a value is present.</param>
        /// <param name="none">A function to invoke if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
        /// the result of the invoked function.
        /// </returns>
        public static Task<TResult> MatchAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, Task<TResult>> some, Func<Task<TResult>> none, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            some.ThrowIfNull();
            none.ThrowIfNull();

            return source.Then(x => x.MatchAsync(some, none, cancellationToken), cancellationToken);
        }

        #endregion
    }
}
