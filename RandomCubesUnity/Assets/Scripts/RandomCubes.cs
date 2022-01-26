/***
* Created by: Cristian Misla
* Date Created: 1/24/2022
*
* Last Edited By: Cristian Misla
* Last Edited: 1/26/2022
* 
* Description: This code is to spawn the cube in random directions at 0,0,0 while it scales until it deletes itself. 
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; //Total number of cubes instatied
    public List<GameObject> gameObjectList;

    void Start()
    {
        gameObjectList = new List<GameObject>(); // Instatates the list
    }

    void Update()
    {
        numberOfCubes++; //add to the number of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube
        gObj.name = "Cube" + numberOfCubes; //name of cube instance
        Vector3 insideUnitSphere = Random.insideUnitSphere;
        gObj.transform.position = insideUnitSphere; //random location within a sphere radius of 1 out from 0,0,0
        gameObjectList.Add(gObj); //add to list
        List<GameObject> removeList = new List<GameObject>();//remove to list

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; //scale multiplied by scaling factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale
            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if(scale <= 0.1f)
        }//end foreach(GameObject goTemp in gameObjectList)

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp); //destory game object list
            
        }//end foreach(GameObject goTemp in removeList)
        //Debug.Log(removeList.Count); //debugs the remove list
    }
}
