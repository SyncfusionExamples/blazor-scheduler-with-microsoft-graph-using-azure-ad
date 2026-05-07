using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace BlazorSchedulerApp.Services
{
    // Minimal file-backed IDistributedCache for local/dev scenarios.
    // Not recommended for production: use Redis/SQL distributed cache instead.
    public class FileDistributedCache : IDistributedCache
    {
        private readonly string _directory;

        public FileDistributedCache(string directory)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
            Directory.CreateDirectory(_directory);
        }

        private string FilePathForKey(string key)
        {
            var sanitized = Convert.ToBase64String(Encoding.UTF8.GetBytes(key))
                .Replace('/', '_')
                .Replace('+', '-')
                .TrimEnd('=');
            return Path.Combine(_directory, sanitized + ".bin");
        }

        public byte[] Get(string key)
        {
            var path = FilePathForKey(key);
            if (!File.Exists(path)) return null;
            return File.ReadAllBytes(path);
        }

        public Task<byte[]> GetAsync(string key, CancellationToken token = default)
            => Task.FromResult(Get(key));

        public void Refresh(string key)
        {
            // No refresh semantics for simple file cache.
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            return Task.CompletedTask;
        }

        public void Remove(string key)
        {
            var path = FilePathForKey(key);
            if (File.Exists(path)) File.Delete(path);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            Remove(key);
            return Task.CompletedTask;
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            var path = FilePathForKey(key);
            File.WriteAllBytes(path, value ?? Array.Empty<byte>());
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            Set(key, value, options);
            return Task.CompletedTask;
        }
    }
}
