using System;
using System.Threading.Tasks;

namespace EveIndustry
{
    public class LazyAsync<T> : Lazy<Task<T>>
    {
        /// <summary>
        ///  Initializes a new instance of the LazyAsync`1 class. When lazy initialization
        ///  occurs, the specified initialization function is used.
        /// </summary>
        /// <param name="taskFunc">The delegate that is invoked to produce the lazily initialized Task when it is needed.</param>
        public LazyAsync(Func<Task<T>> taskFunc) :
            base(() => Task.Factory.StartNew(taskFunc).Unwrap())
        { }
    }
}