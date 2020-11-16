using Lazlo.Common.Core;
using Lazlo.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazlo.Common.Extensions
{
    public static class SmartContextExtensions
    {
        public static SmartBase<T> Map<T>(this SmartBase<T> to, SmartBase<T> from)
        {
            to.Data = from.Data;
            to.Properties = from.Properties;
            to.CreatedOn = from.CreatedOn;

            return to;
        }

        public static SmartBase<T> Map<T>(this SmartContext<T> to, SmartContext<T> from)
        {
            to.Data = from.Data;
            to.Properties = from.Properties;
            to.CreatedOn = from.CreatedOn;
            to.Uuid = from.Uuid;
            to.Latitude = from.Latitude;
            to.Longitude = from.Longitude;

            return to;
        }

        public static SmartBase<T> Map<T>(this SmartContext<T> to, SmartRequest<T> smartRequest)
        {
            to.Data = smartRequest.Data;
            to.CreatedOn = smartRequest.CreatedOn;
            to.Uuid = smartRequest.Uuid;
            to.Latitude = smartRequest.Latitude;
            to.Longitude = smartRequest.Longitude;

            return to;
        }
    }
}

