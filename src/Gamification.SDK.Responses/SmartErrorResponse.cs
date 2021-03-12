using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Responses
{
    [Serializable]
    public class PropertyErrorResponseV2
    {
        public PropertyErrorResponseV2() { }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "propertyName")]
        public string PropertyName { get; set; }
    }

    [Serializable]
    public class ErrorResponseV2
    {
        public ErrorResponseV2() { }

        public ErrorResponseV2(Exception ex) { Message = ex.Message; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "modelErrors")]
        public List<PropertyErrorResponseV2> ModelErrors { get; set; } = new List<PropertyErrorResponseV2>();
    }

    [Serializable]
    public class SmartErrorResponseV2
    {
        public SmartErrorResponseV2() { }

        public SmartErrorResponseV2(Guid correlationRefId)
        {
            if (correlationRefId.Equals(Guid.Empty)) Error.ModelErrors.Add(new PropertyErrorResponseV2() { PropertyName = nameof(CorrelationRefId), Message = $"{nameof(correlationRefId)} must not equal Guid.Empty"});
            this.CorrelationRefId = correlationRefId;
        }

        public SmartErrorResponseV2(Guid correlationRefId, Exception ex)
        {
            if (correlationRefId.Equals(Guid.Empty)) Error.ModelErrors.Add(new PropertyErrorResponseV2() { PropertyName = nameof(CorrelationRefId), Message = $"{nameof(correlationRefId)} must not equal Guid.Empty" });
            this.CorrelationRefId = correlationRefId;
        }

        public SmartErrorResponseV2(Guid correlationRefId, ErrorResponseV2 error)
        {
            if (correlationRefId.Equals(Guid.Empty)) Error.ModelErrors.Add(new PropertyErrorResponseV2() { PropertyName = nameof(CorrelationRefId), Message = $"{nameof(correlationRefId)} must not equal Guid.Empty" });
            this.CorrelationRefId = correlationRefId;
            this.Error = error;
        }

        [JsonProperty(PropertyName = "correlationId")]
        [JsonRequired]
        public Guid CorrelationRefId { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        [JsonRequired]
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

        [JsonProperty(PropertyName = "error")]
        public ErrorResponseV2 Error { get; set; } = new ErrorResponseV2();
    }
}
