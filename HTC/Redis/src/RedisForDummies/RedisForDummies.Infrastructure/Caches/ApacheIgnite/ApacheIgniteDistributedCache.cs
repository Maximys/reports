using Apache.Extensions.Caching.Ignite;
using Microsoft.Extensions.Caching.Distributed;
using RedisForDummies.Application.Caches.ApacheIgnite;

namespace RedisForDummies.Infrastructure.Caches.ApacheIgnite
{
    /// <summary>
    /// Распределенный кэш, представленный Apache Ignite'ом.
    /// </summary>
    public class ApacheIgniteDistributedCache : IApacheIgniteDistributedCache
    {
        /// <summary>
        /// Кэш Apache Ignite.
        /// </summary>
        protected IgniteDistributedCache _igniteCache { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ApacheIgniteDistributedCache"/>.
        /// </summary>
        /// <param name="igniteCache">Кэш Apache Ignite.</param>
        public ApacheIgniteDistributedCache(IgniteDistributedCache igniteCache)
        {
            _igniteCache = igniteCache;
        }

        /// <inheritdoc/>
        public byte[]? Get(string key)
        {
            return _igniteCache.Get(key);
        }

        /// <inheritdoc/>
        public Task<byte[]?> GetAsync(string key, CancellationToken token = default)
        {
            return _igniteCache.GetAsync(key, token);
        }

        /// <inheritdoc/>
        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            _igniteCache.Set(key, value, options);
        }

        /// <inheritdoc/>
        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            return _igniteCache.SetAsync(key, value, options, token);
        }

        /// <inheritdoc/>
        public void Refresh(string key)
        {
            _igniteCache.Refresh(key);
        }

        /// <inheritdoc/>
        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            return _igniteCache.RefreshAsync(key, token);
        }

        /// <inheritdoc/>
        public void Remove(string key)
        {
            _igniteCache.Remove(key);
        }

        /// <inheritdoc/>
        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            return _igniteCache.RemoveAsync(key, token);
        }
    }
}
