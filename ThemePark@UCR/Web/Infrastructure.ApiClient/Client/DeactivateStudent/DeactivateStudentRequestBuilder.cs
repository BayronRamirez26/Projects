// <auto-generated/>
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeactivateStudent.Item;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeactivateStudent {
    /// <summary>
    /// Builds and executes requests for operations under \deactivate-student
    /// </summary>
    public class DeactivateStudentRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>Gets an item from the UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.deactivateStudent.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        /// <returns>A <see cref="WithStudentItemRequestBuilder"/></returns>
        public WithStudentItemRequestBuilder this[Guid position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("studentId", position);
                return new WithStudentItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>Gets an item from the UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.deactivateStudent.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        /// <returns>A <see cref="WithStudentItemRequestBuilder"/></returns>
        [Obsolete("This indexer is deprecated and will be removed in the next major version. Use the one with the typed parameter instead.")]
        public WithStudentItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("studentId", position);
                return new WithStudentItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="DeactivateStudentRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DeactivateStudentRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deactivate-student", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="DeactivateStudentRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DeactivateStudentRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deactivate-student", rawUrl)
        {
        }
    }
}
