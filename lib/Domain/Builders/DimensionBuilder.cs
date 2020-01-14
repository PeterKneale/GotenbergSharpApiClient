// Gotenberg.Sharp.Api.Client - Copyright (c) 2019 CaptiveAire

using Gotenberg.Sharp.API.Client.Domain.Requests;
using JetBrains.Annotations;

namespace Gotenberg.Sharp.API.Client.Domain.Builders
{
    [PublicAPI]
    public class DimensionBuilder<TRequest> : BaseBuilder<TRequest> where TRequest: class, IDimensional
    {
        [PublicAPI]
        public DimensionBuilder(TRequest request)
        {
            this.Request = request;
            this.Request.Dimensions ??= new DocumentDimensions();
        }
        
        [PublicAPI]
        public DimensionBuilder<TRequest> PaperWidth(double width)
        {
            this.Request.Dimensions.PaperWidth = width;
            return this;
        }

        [PublicAPI]
        public DimensionBuilder<TRequest> PaperHeight(double height)
        {
            this.Request.Dimensions.PaperHeight = height;
            return this;
        }

        [PublicAPI]
        public DimensionBuilder<TRequest> MarginTop(double marginTop)
        {
            this.Request.Dimensions.MarginTop = marginTop;
            return this;
        }

        [PublicAPI]
        public DimensionBuilder<TRequest> MarginBottom(double marginBottom)
        {
            this.Request.Dimensions.MarginBottom = marginBottom;
            return this;
        }
        
        [PublicAPI]
        public DimensionBuilder<TRequest> MarginLeft(double marginLeft)
        {
            this.Request.Dimensions.MarginLeft = marginLeft;
            return this;
        }
        
        [PublicAPI]
        public DimensionBuilder<TRequest> MarginRight(double marginRight)
        {
            this.Request.Dimensions.MarginRight = marginRight;
            return this;
        }

        [PublicAPI]
        public DimensionBuilder<TRequest> LandScape(bool landscape)
        {
            this.Request.Dimensions.Landscape = landscape;
            return this;
        }
    }
}