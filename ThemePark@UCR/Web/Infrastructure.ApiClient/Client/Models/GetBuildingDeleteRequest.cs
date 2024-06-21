// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models {
    public class GetBuildingDeleteRequest : IParsable 
    {
        /// <summary>The buildingAcronym property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? BuildingAcronym { get; set; }
#nullable restore
#else
        public string BuildingAcronym { get; set; }
#endif
        /// <summary>The campusName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CampusName { get; set; }
#nullable restore
#else
        public string CampusName { get; set; }
#endif
        /// <summary>The siteName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SiteName { get; set; }
#nullable restore
#else
        public string SiteName { get; set; }
#endif
        /// <summary>The universityName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UniversityName { get; set; }
#nullable restore
#else
        public string UniversityName { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="GetBuildingDeleteRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static GetBuildingDeleteRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GetBuildingDeleteRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"buildingAcronym", n => { BuildingAcronym = n.GetStringValue(); } },
                {"campusName", n => { CampusName = n.GetStringValue(); } },
                {"siteName", n => { SiteName = n.GetStringValue(); } },
                {"universityName", n => { UniversityName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("buildingAcronym", BuildingAcronym);
            writer.WriteStringValue("campusName", CampusName);
            writer.WriteStringValue("siteName", SiteName);
            writer.WriteStringValue("universityName", UniversityName);
        }
    }
}
