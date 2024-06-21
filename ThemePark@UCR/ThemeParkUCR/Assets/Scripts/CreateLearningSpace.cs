using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Data.SqlClient;
// using System.Data;

public class CreateLearningSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateLearningSpace3D(10, 1, 10, Color.blue, Color.red, Color.green);
        
        // first we need to read the sizeX and sizeY from the database
        // then change the size of the floor
        // Debug.Log("Connecting to the database to get the size of the floor");
        // connectionString = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // SqlConnection conn = new SqlConnection(connectionString);

        // try{
        //     conn.Open();
        //     Debug.Log("Connection Opened");
        // }
        // catch (Exception e){
        //     Debug.Log("Error: " + e.Message);
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        // cada 5 min
        // create bichito
        
    }

    /// <summary>
    /// Create a 3D learning space with a roof, right wall, left wall, back wall and front wall
    /// The roof as a given color, same as the walls and the floor
    /// </summary>
    public void CreateLearningSpace3D(float sizeX, float sizeY, float sizeZ, Color roofColor, Color wallColor, Color floorColor){
        // create the roof
        GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
        roof.transform.localScale = new Vector3(sizeX, 0.1f, sizeZ);
        roof.transform.position = new Vector3(0, sizeY, 0);
        roof.GetComponent<Renderer>().material.color = roofColor;

        // create right wall
        GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightWall.transform.localScale = new Vector3(0.1f, sizeY, sizeZ);
        rightWall.transform.position = new Vector3(sizeX/2, sizeY/2, 0);
        rightWall.GetComponent<Renderer>().material.color = wallColor;

        // create left wall
        GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftWall.transform.localScale = new Vector3(0.1f, sizeY, sizeZ);
        leftWall.transform.position = new Vector3(-sizeX/2, sizeY/2, 0);
        leftWall.GetComponent<Renderer>().material.color = wallColor;

        // create back wall
        GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backWall.transform.localScale = new Vector3(sizeX, sizeY, 0.1f);
        backWall.transform.position = new Vector3(0, sizeY/2, sizeZ/2);
        backWall.GetComponent<Renderer>().material.color = wallColor;

        // create front wall
        GameObject frontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        frontWall.transform.localScale = new Vector3(sizeX, sizeY, 0.1f);
        frontWall.transform.position = new Vector3(0, sizeY/2, -sizeZ/2);
        frontWall.GetComponent<Renderer>().material.color = wallColor;

        // change the floor color
        GetComponent<Renderer>().material.color = floorColor;
        
    }
}
