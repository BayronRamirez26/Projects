// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using UCR.ECCI.IS.ExampleProject.Infrastructure.ApiClient.Client.Models;
namespace UCR.ECCI.IS.ExampleProject.Infrastructure.ApiClient.Client.GetInteractiveScreenOfLearningSpace {
    /// <summary>
    /// Builds and executes requests for operations under \get-interactive-screen-of-learning-space
    /// </summary>
    public class GetInteractiveScreenOfLearningSpaceRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>
        /// Instantiates a new <see cref="GetInteractiveScreenOfLearningSpaceRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetInteractiveScreenOfLearningSpaceRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/get-interactive-screen-of-learning-space?inputId={inputId}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="GetInteractiveScreenOfLearningSpaceRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetInteractiveScreenOfLearningSpaceRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/get-interactive-screen-of-learning-space?inputId={inputId}", rawUrl)
        {
        }
        /// <returns>A List&lt;InteractiveScreen&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<InteractiveScreen>?> PostAsync(Action<RequestConfiguration<GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<InteractiveScreen>> PostAsync(Action<RequestConfiguration<GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToPostRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<InteractiveScreen>(requestInfo, InteractiveScreen.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
            return collectionResult?.ToList();
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="GetInteractiveScreenOfLearningSpaceRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public GetInteractiveScreenOfLearningSpaceRequestBuilder WithUrl(string rawUrl)
        {
            return new GetInteractiveScreenOfLearningSpaceRequestBuilder(rawUrl, RequestAdapter);
        }
        public class GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters 
        {
            [QueryParameter("inputId")]
            public Guid? InputId { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class GetInteractiveScreenOfLearningSpaceRequestBuilderPostRequestConfiguration : RequestConfiguration<GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters> 
        {
        }
    }
}
