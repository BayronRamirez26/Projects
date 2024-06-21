using TMPro;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour
{
    public class LevelPresenter : MonoBehaviour
    {

        // thickness constant readonly
        private const float THICKNESS_SIZE = 0.1f;

        [SerializeField]
        private TextMeshProUGUI _levelLabelTextMeshPro;

        [SerializeField]
        private GameObject _roof;

        [SerializeField]
        private GameObject _floor;

        [SerializeField]
        private GameObject _rightWall;

        [SerializeField]
        private GameObject _leftWall;

        [SerializeField]
        private GameObject _backWall;

        [SerializeField]
        private GameObject _frontWall;

        public void OnLoad(Level level)
        {
            // here load all the level data to render the level in Unity
            _levelLabelTextMeshPro.text = $" {level.BuildingAcronym.Value} {level.LevelNumber.Value}";

            // get the size of the level: y and z are inverted
            var sizeX = (float)level.SizeX.Value;
            var sizeY = (float)level.SizeZ.Value * 2;
            var sizeZ = (float)level.SizeY.Value;

            // TODO: put real values for level
            _roof.transform.localScale = new Vector3(sizeX, THICKNESS_SIZE, sizeZ);
            _roof.transform.position = _roof.transform.position + new Vector3(0, sizeY, 0);
            ColorUtility.TryParseHtmlString(level.CeilingColor.Value, out var roofColor);
            _roof.GetComponent<Renderer>().material.color = roofColor;

            _rightWall.transform.localScale = new Vector3(THICKNESS_SIZE, sizeY, sizeZ);
            _rightWall.transform.position = _rightWall.transform.position + new Vector3(sizeX / 2, sizeY / 2, 0);
            ColorUtility.TryParseHtmlString(level.WallsColor.Value, out var rightWallColor);
            _rightWall.GetComponent<Renderer>().material.color = rightWallColor;

            _leftWall.transform.localScale = new Vector3(THICKNESS_SIZE, sizeY, sizeZ);
            _leftWall.transform.position = _leftWall.transform.position + new Vector3(-sizeX / 2, sizeY / 2, 0);
            ColorUtility.TryParseHtmlString(level.WallsColor.Value, out var leftWallColor);
            _leftWall.GetComponent<Renderer>().material.color = leftWallColor;

            _backWall.transform.localScale = new Vector3(sizeX, sizeY, THICKNESS_SIZE);
            _backWall.transform.position = _backWall.transform.position + new Vector3(0, sizeY / 2, sizeZ / 2);
            ColorUtility.TryParseHtmlString(level.WallsColor.Value, out var backWallColor);
            _backWall.GetComponent<Renderer>().material.color = backWallColor;

            _frontWall.transform.localScale = new Vector3(sizeX, sizeY, THICKNESS_SIZE);
            _frontWall.transform.position = _frontWall.transform.position + new Vector3(0, sizeY / 2, -sizeZ / 2);
            ColorUtility.TryParseHtmlString(level.WallsColor.Value, out var frontWallColor);
            _frontWall.GetComponent<Renderer>().material.color = frontWallColor;

            _floor.transform.localScale = new Vector3(sizeX, THICKNESS_SIZE, sizeZ);
            _floor.transform.position = _floor.transform.position + new Vector3(0, 0, 0);
            ColorUtility.TryParseHtmlString(level.FloorColor.Value, out var floorColor); ;
            _floor.GetComponent<Renderer>().material.color = floorColor;

        }
    }
}
