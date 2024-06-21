using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities
{
    /// <summary>
    /// This represents the AccessPoint entity in our system
    /// This are the entry and exit point to LearningSpaces
    /// </summary>
    public class AccessPoint
    {

        /// <summary>
        /// Primary constructor
        /// </summary>
        /// <param name="accessPointId">Guid that identify the access point</param>
        /// <param name="learningSpaceId">Guid of LearningSpace assign</param>
        /// <param name="levelId">Guid of level from building assign</param>
        /// <param name="coordX">Coordenates X</param>
        /// <param name="coordY">Coordenates Y</param>
        /// <param name="coordZ">Coordenates Z</param>
        public AccessPoint(
               GuidWrapper accessPointId,
               GuidWrapper learningSpaceId,
               GuidWrapper levelId,
               double coordX,
               double coordY,
               double coordZ,
               double rotationX,
               double rotationY
            )
        {
            AccessPointId = accessPointId;
            LearningSpaceId = learningSpaceId;
            LevelId = levelId;
            CoordX = coordX;
            CoordY = coordY;
            CoordZ = coordZ;
            RotationX = rotationX;
            RotationY = rotationY;
        }

        public GuidWrapper AccessPointId { get; } // Guid AccessPointId
        public GuidWrapper LearningSpaceId { get; } // Guid LearningSpaceId
        public GuidWrapper LevelId { get; } // Guid LevelId
        public double CoordX { get; } // X coordenates
        public double CoordY { get; } // Y coordenates
        public double CoordZ { get; } // Z coordenates
        public double RotationX { get; } // X rotation
        public double RotationY { get; } // Y rotation

    }
}
