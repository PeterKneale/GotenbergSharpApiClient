// Gotenberg.Sharp.Api.Client - Copyright (c) 2019 CaptiveAire

using System;
using Gotenberg.Sharp.API.Client.Domain.Requests;
using JetBrains.Annotations;

namespace Gotenberg.Sharp.API.Client.Domain.Builders
{
    [PublicAPI]
    public class PdfRequestBuilder: BaseBuilder<PdfRequest> 
    {
        [PublicAPI]
        public PdfRequestBuilder() => Request = new PdfRequest();

        [PublicAPI]
        public DocumentBuilder Document=> new DocumentBuilder(Request);

        [PublicAPI]
        public DimensionBuilder<PdfRequest> Dimensions => new DimensionBuilder<PdfRequest>(Request);
        
        [PublicAPI]
        public ConfigBuilder<PdfRequest> ConfigureRequest => new ConfigBuilder<PdfRequest>(Request);
        
        [PublicAPI]
        public IConversionRequest Build()
        {
             if(this.Request.Content == null) throw new NullReferenceException("Request.Content is null");
             this.Request.Dimensions ??= DocumentDimensions.ToChromeDefaults();
            
            return Request;
        }
    
    }
 }