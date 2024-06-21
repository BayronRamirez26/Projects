// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.CreateWhiteboardFromTemplate {
    /// <summary>
    /// Builds and executes requests for operations under \create-whiteboard-from-template
    /// </summary>
    public class CreateWhiteboardFromTemplateRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>
        /// Instantiates a new <see cref="CreateWhiteboardFromTemplateRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CreateWhiteboardFromTemplateRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/create-whiteboard-from-template?learningSpaceId={learningSpaceId}&templateId={templateId}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="CreateWhiteboardFromTemplateRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CreateWhiteboardFromTemplateRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/create-whiteboard-from-template?learningSpaceId={learningSpaceId}&templateId={templateId}", rawUrl)
        {
        }
        /// <returns>A <see cref="bool"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<bool?> PostAsync(Action<RequestConfiguration<CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<bool?> PostAsync(Action<RequestConfiguration<CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToPostRequestInformation(requestConfiguration);
            return await RequestAdapter.SendPrimitiveAsync<bool?>(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="CreateWhiteboardFromTemplateRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public CreateWhiteboardFromTemplateRequestBuilder WithUrl(string rawUrl)
        {
            return new CreateWhiteboardFromTemplateRequestBuilder(rawUrl, RequestAdapter);
        }
        public class CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters 
        {
            [QueryParameter("learningSpaceId")]
            public Guid? LearningSpaceId { get; set; }
            [QueryParameter("templateId")]
            public Guid? TemplateId { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class CreateWhiteboardFromTemplateRequestBuilderPostRequestConfiguration : RequestConfiguration<CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters> 
        {
        }
    }
}