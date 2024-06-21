// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetLearningSpaceTypeByLstypeid {
    /// <summary>
    /// Builds and executes requests for operations under \get-learning-space-type-by-lstypeid
    /// </summary>
    public class GetLearningSpaceTypeByLstypeidRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>
        /// Instantiates a new <see cref="GetLearningSpaceTypeByLstypeidRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetLearningSpaceTypeByLstypeidRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/get-learning-space-type-by-lstypeid?inputId={inputId}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="GetLearningSpaceTypeByLstypeidRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetLearningSpaceTypeByLstypeidRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/get-learning-space-type-by-lstypeid?inputId={inputId}", rawUrl)
        {
        }
        /// <returns>A List&lt;LearningSpaces&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<LearningSpaces>?> PostAsync(Action<RequestConfiguration<GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<LearningSpaces>> PostAsync(Action<RequestConfiguration<GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToPostRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<LearningSpaces>(requestInfo, LearningSpaces.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
            return collectionResult?.ToList();
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="GetLearningSpaceTypeByLstypeidRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public GetLearningSpaceTypeByLstypeidRequestBuilder WithUrl(string rawUrl)
        {
            return new GetLearningSpaceTypeByLstypeidRequestBuilder(rawUrl, RequestAdapter);
        }
        public class GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters 
        {
            [QueryParameter("inputId")]
            public Guid? InputId { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class GetLearningSpaceTypeByLstypeidRequestBuilderPostRequestConfiguration : RequestConfiguration<GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters> 
        {
        }
    }
}
