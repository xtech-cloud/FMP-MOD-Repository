using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class MinIOClient
    {
        private readonly IOptions<MinIOSettings> settings_;
        private MinioClient client_;
        private MinioClient presignedClient_;

        public MinIOClient(IOptions<MinIOSettings> _settings)
        {
            settings_ = _settings;
            client_ = new MinioClient()
                .WithEndpoint(settings_.Value.Endpoint)
                .WithCredentials(settings_.Value.AccessKey, settings_.Value.SecretKey)
                .Build();
            presignedClient_ = new MinioClient()
                .WithEndpoint(settings_.Value.Address)
                .WithCredentials(settings_.Value.AccessKey, settings_.Value.SecretKey)
                .Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_expiry">过期时间，单位秒</param>
        /// <returns></returns>
        public async Task<string> PresignedPutObject(string _path, int _expiry)
        {
            PresignedPutObjectArgs args = new PresignedPutObjectArgs()
                                                    .WithBucket(settings_.Value.Bucket)
                                                    .WithObject(_path).WithExpiry(_expiry);
            return await presignedClient_.PresignedPutObjectAsync(args);
        }

        public async Task<KeyValuePair<string ,ulong>> StateObject(string _path)
        {
            StatObjectArgs statObjectArgs = new StatObjectArgs()
                                            .WithBucket(settings_.Value.Bucket)
                                            .WithObject(_path);
            ObjectStat objectStat = await client_.StatObjectAsync(statObjectArgs);
            return new KeyValuePair<string, ulong>(objectStat.ETag, (ulong)objectStat.Size);
        }


    }
}
