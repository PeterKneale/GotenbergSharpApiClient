using System;
using System.Collections.Generic;
using Gotenberg.Sharp.API.Client.Domain.Requests;
using Gotenberg.Sharp.API.Client.Extensions;
using JetBrains.Annotations;

namespace Gotenberg.Sharp.API.Client.Domain.Builders
{
    public class UrlRequestBuilder: BaseBuilder<UrlRequest>
    {
        [PublicAPI]
        public UrlRequestBuilder() => this.Request = new UrlRequest();
        
        #region simple props
        
        [PublicAPI]
        public UrlRequestBuilder SetUrl(string url)
        {
            if(url.IsNotSet()) throw new ArgumentException("invalid url");
            return SetUrl(new Uri(url));
        }
        
        [PublicAPI]
        public UrlRequestBuilder SetUrl(Uri url)
        {
            var isUsable = url.IsAbsoluteUri && url.IsWellFormedOriginalString();
            this.Request.Url = isUsable ? url : throw new ArgumentException("builder must set absolute uri");
            
            return this;
        }
        
        [PublicAPI]
        public UrlRequestBuilder SetUrl(UriBuilder builder)
        {
            this.Request.Url = builder.Uri.IsAbsoluteUri ? 
                builder.Uri : throw new ArgumentException("builder must set absolute uri");
            
            return this;
        }

        [PublicAPI]
        public UrlRequestBuilder SetRemoteHeaders(string key, string value)
        {
            if(key.IsNotSet()) throw new ArgumentException("builder must set absolute uri");
            
            #if NETSTANDARD2_0
                this.Request.RemoteUrlHeader = new KeyValuePair<string, string>(key,value); 
            #else
                this.Request.RemoteUrlHeader = KeyValuePair.Create(key, value);
            #endif
            
            return this;
        }

        #endregion
        
        #region faceted props
        
        [PublicAPI]
        public DimensionBuilder<UrlRequest> Dimensions => new DimensionBuilder<UrlRequest>(Request);

        [PublicAPI]
        public ConfigBuilder<UrlRequest> ConfigureRequest => new ConfigBuilder<UrlRequest>(Request);
        
        #endregion
        
        [PublicAPI]
        public UrlRequest Build()
        {
            if(this.Request.Url == null) throw new NullReferenceException("Request.Url is null");
            this.Request.Dimensions ??= DocumentDimensions.ToChromeDefaults();
            
            return this.Request;
        }

    }
}