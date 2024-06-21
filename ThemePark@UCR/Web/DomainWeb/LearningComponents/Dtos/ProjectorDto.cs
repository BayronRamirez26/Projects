﻿using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;

public class ProjectorDto
{

    public int learningComponentId { get; set; }
    public string learningComponentName { get; set; }
    public double PositionX { get; set; } = 0.0;
    public double PositionY { get; set; } = 0.0;
    public double PositionZ { get; set; } = 0.0;
    public double SizeX { get; set; } = 0;
    public double SizeY { get; set; } = 0;
    public double RotationX { get; set; } = 0;
    public double RotationY { get; set; } = 0;

    public Guid LearningSpaceId { get; set; }


    public ProjectorDto(int learningComponentId, string learningComponentName, double positionX, double positionY, double positionZ, float sizeX, float sizeY, float rotationX, float rotationY, Guid learningSpaceId)
    {
        this.learningComponentId = learningComponentId;
        this.learningComponentName = learningComponentName;
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        SizeX = sizeX;
        SizeY = sizeY;
        RotationX = rotationX;
        RotationY = rotationY;
        LearningSpaceId = learningSpaceId;

    }

    public ProjectorDto( string learningComponentName, double positionX, double positionY, double positionZ, float sizeX, float sizeY, float rotationX, float rotationY, Guid learningSpaceId)
    {
        this.learningComponentName = learningComponentName;
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        SizeX = sizeX;
        SizeY = sizeY;
        RotationX = rotationX;
        RotationY = rotationY;
        LearningSpaceId = learningSpaceId;

    }


}