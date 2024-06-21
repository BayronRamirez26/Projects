// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace UCR.ECCI.IS.ExampleProject.Infrastructure.ApiClient.Client.Models {
    public class Whiteboard : IParsable 
    {
        /// <summary>The learningComponentAssetId property</summary>
        public int? LearningComponentAssetId { get; set; }
        /// <summary>The learningComponentName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public MediumName? LearningComponentName { get; set; }
#nullable restore
#else
        public MediumName LearningComponentName { get; set; }
#endif
        /// <summary>The learningSpaceId property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GuidWrapper? LearningSpaceId { get; set; }
#nullable restore
#else
        public GuidWrapper LearningSpaceId { get; set; }
#endif
        /// <summary>The positionX property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Coordinate? PositionX { get; set; }
#nullable restore
#else
        public Coordinate PositionX { get; set; }
#endif
        /// <summary>The positionY property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Coordinate? PositionY { get; set; }
#nullable restore
#else
        public Coordinate PositionY { get; set; }
#endif
        /// <summary>The positionZ property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Coordinate? PositionZ { get; set; }
#nullable restore
#else
        public Coordinate PositionZ { get; set; }
#endif
        /// <summary>The sizeX property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Size? SizeX { get; set; }
#nullable restore
#else
        public Size SizeX { get; set; }
#endif
        /// <summary>The sizeY property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Size? SizeY { get; set; }
#nullable restore
#else
        public Size SizeY { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Whiteboard"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Whiteboard CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Whiteboard();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"learningComponentAssetId", n => { LearningComponentAssetId = n.GetIntValue(); } },
                {"learningComponentName", n => { LearningComponentName = n.GetObjectValue<MediumName>(MediumName.CreateFromDiscriminatorValue); } },
                {"learningSpaceId", n => { LearningSpaceId = n.GetObjectValue<GuidWrapper>(GuidWrapper.CreateFromDiscriminatorValue); } },
                {"positionX", n => { PositionX = n.GetObjectValue<Coordinate>(Coordinate.CreateFromDiscriminatorValue); } },
                {"positionY", n => { PositionY = n.GetObjectValue<Coordinate>(Coordinate.CreateFromDiscriminatorValue); } },
                {"positionZ", n => { PositionZ = n.GetObjectValue<Coordinate>(Coordinate.CreateFromDiscriminatorValue); } },
                {"sizeX", n => { SizeX = n.GetObjectValue<Size>(Size.CreateFromDiscriminatorValue); } },
                {"sizeY", n => { SizeY = n.GetObjectValue<Size>(Size.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("learningComponentAssetId", LearningComponentAssetId);
            writer.WriteObjectValue<MediumName>("learningComponentName", LearningComponentName);
            writer.WriteObjectValue<GuidWrapper>("learningSpaceId", LearningSpaceId);
            writer.WriteObjectValue<Coordinate>("positionX", PositionX);
            writer.WriteObjectValue<Coordinate>("positionY", PositionY);
            writer.WriteObjectValue<Coordinate>("positionZ", PositionZ);
            writer.WriteObjectValue<Size>("sizeX", SizeX);
            writer.WriteObjectValue<Size>("sizeY", SizeY);
        }
    }
}
