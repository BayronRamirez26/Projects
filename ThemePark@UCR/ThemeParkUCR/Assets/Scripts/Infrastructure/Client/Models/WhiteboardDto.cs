// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models {
    public class WhiteboardDto : IParsable 
    {
        /// <summary>The learningComponenName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LearningComponenName { get; set; }
#nullable restore
#else
        public string LearningComponenName { get; set; }
#endif
        /// <summary>The learningComponentId property</summary>
        public int? LearningComponentId { get; set; }
        /// <summary>The learningSpaceId property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GuidWrapper? LearningSpaceId { get; set; }
#nullable restore
#else
        public GuidWrapper LearningSpaceId { get; set; }
#endif
        /// <summary>The positionX property</summary>
        public double? PositionX { get; set; }
        /// <summary>The positionY property</summary>
        public double? PositionY { get; set; }
        /// <summary>The positionZ property</summary>
        public double? PositionZ { get; set; }
        /// <summary>The rotationX property</summary>
        public double? RotationX { get; set; }
        /// <summary>The rotationY property</summary>
        public double? RotationY { get; set; }
        /// <summary>The sizeX property</summary>
        public double? SizeX { get; set; }
        /// <summary>The sizeY property</summary>
        public double? SizeY { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="WhiteboardDto"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WhiteboardDto CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WhiteboardDto();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"learningComponenName", n => { LearningComponenName = n.GetStringValue(); } },
                {"learningComponentId", n => { LearningComponentId = n.GetIntValue(); } },
                {"learningSpaceId", n => { LearningSpaceId = n.GetObjectValue<GuidWrapper>(GuidWrapper.CreateFromDiscriminatorValue); } },
                {"positionX", n => { PositionX = n.GetDoubleValue(); } },
                {"positionY", n => { PositionY = n.GetDoubleValue(); } },
                {"positionZ", n => { PositionZ = n.GetDoubleValue(); } },
                {"rotationX", n => { RotationX = n.GetDoubleValue(); } },
                {"rotationY", n => { RotationY = n.GetDoubleValue(); } },
                {"sizeX", n => { SizeX = n.GetDoubleValue(); } },
                {"sizeY", n => { SizeY = n.GetDoubleValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("learningComponenName", LearningComponenName);
            writer.WriteIntValue("learningComponentId", LearningComponentId);
            writer.WriteObjectValue<GuidWrapper>("learningSpaceId", LearningSpaceId);
            writer.WriteDoubleValue("positionX", PositionX);
            writer.WriteDoubleValue("positionY", PositionY);
            writer.WriteDoubleValue("positionZ", PositionZ);
            writer.WriteDoubleValue("rotationX", RotationX);
            writer.WriteDoubleValue("rotationY", RotationY);
            writer.WriteDoubleValue("sizeX", SizeX);
            writer.WriteDoubleValue("sizeY", SizeY);
        }
    }
}
