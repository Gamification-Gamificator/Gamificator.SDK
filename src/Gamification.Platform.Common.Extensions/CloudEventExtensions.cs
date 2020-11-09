using CloudNative.CloudEvents;
using Lazlo.Common.Core;
using Lazlo.Common.Requests;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace Gamification.Platform.Common.Extensions
{
    public static class CloudEventExtensions
    {
        public static CloudEvent ToCloudEvent<T>(this SmartRequest<T> request, Uri uri)
        {
            return new CloudEvent(request.Data.GetType().ToString(), uri)
            {
                SpecVersion = CloudEventsSpecVersion.V1_0,
                Subject = $"Request",
                Time = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                DataContentType = new ContentType("application/json"),
                Data = JsonConvert.SerializeObject(request)
            };
        }

        public static CloudEvent ToCloudEvent<T>(this SmartContext<T> ctx, Uri uri)
        {
            return new CloudEvent(ctx.Data.GetType().ToString(), uri)
            {
                SpecVersion = CloudEventsSpecVersion.V1_0,
                Subject = $"Context",
                Time = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                DataContentType = new ContentType("application/json"),
                Data = JsonConvert.SerializeObject(ctx)
            };
        }
    }
}
