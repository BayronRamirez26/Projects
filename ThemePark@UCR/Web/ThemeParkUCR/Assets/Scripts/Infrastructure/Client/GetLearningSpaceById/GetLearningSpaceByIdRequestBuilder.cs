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
namespace UCR.ECCI.IS.ExampleProject.Infrastructure.ApiClient.Client.GetLearningSpaceById {
    /// <summary>
    /// Builds and executes requests for operations under \get-learning-space-by-id
    /// </summary>
    public class GetLearningSpaceByIdRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>
        /// Instantiates a new <see cref="GetLearningSpaceByIdRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetLearningSpaceByIdRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/get-learning-space-by-id?inputId={inputId}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="GetLearningSpaceByIdRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetLearningSpaceByIdRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/get-learning-space-by-id?inputId={inputId}", rawUrl)
        {
        }
        /// <returns>A <see cref="LearningSpaces"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<LearningSpaces?> PostAsync(Action<RequestConfiguration<GetLearningSpaceByIdRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<LearningSpaces> PostAsync(Action<RequestConfiguration<GetLearningSpaceByIdRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToPostRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<LearningSpaces>(requestInfo, LearningSpaces.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<GetLearningSpaceByIdRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<GetLearningSpaceByIdRequestBuilderPostQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="GetLearningSpaceByIdRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public GetLearningSpaceByIdRequestBuilder WithUrl(string rawUrl)
        {
            return new GetLearningSpaceByIdRequestBuilder(rawUrl, RequestAdapter);
        }
        public class GetLearningSpaceByIdRequestBuilderPostQueryParameters 
        {
            [QueryParameter("inputId")]
            public Guid? InputId { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class GetLearningSpaceByIdRequestBuilderPostRequestConfiguration : RequestConfiguration<GetLearningSpaceByIdRequestBuilderPostQueryParameters> 
        {
        }
    }
}
