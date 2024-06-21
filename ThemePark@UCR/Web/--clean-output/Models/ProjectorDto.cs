// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Models {
    #pragma warning disable CS1591
    public class ProjectorDto : IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>The learningComponentId property</summary>
        public int? LearningComponentId { get; set; }
        /// <summary>The learningComponentName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LearningComponentName { get; set; }
#nullable restore
#else
        public string LearningComponentName { get; set; }
#endif
        /// <summary>The positionX property</summary>
        public double? PositionX { get; set; }
        /// <summary>The positionY property</summary>
        public double? PositionY { get; set; }
        /// <summary>The positionZ property</summary>
        public double? PositionZ { get; set; }
        /// <summary>The sizeX property</summary>
        public float? SizeX { get; set; }
        /// <summary>The sizeY property</summary>
        public float? SizeY { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="ProjectorDto"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ProjectorDto CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ProjectorDto();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"learningComponentId", n => { LearningComponentId = n.GetIntValue(); } },
                {"learningComponentName", n => { LearningComponentName = n.GetStringValue(); } },
                {"positionX", n => { PositionX = n.GetDoubleValue(); } },
                {"positionY", n => { PositionY = n.GetDoubleValue(); } },
                {"positionZ", n => { PositionZ = n.GetDoubleValue(); } },
                {"sizeX", n => { SizeX = n.GetFloatValue(); } },
                {"sizeY", n => { SizeY = n.GetFloatValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("learningComponentId", LearningComponentId);
            writer.WriteStringValue("learningComponentName", LearningComponentName);
            writer.WriteDoubleValue("positionX", PositionX);
            writer.WriteDoubleValue("positionY", PositionY);
            writer.WriteDoubleValue("positionZ", PositionZ);
            writer.WriteFloatValue("sizeX", SizeX);
            writer.WriteFloatValue("sizeY", SizeY);
        }
    }
}