using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirst : MonoBehaviour
{

    public GameObject SceneController;
    public GameObject VisitMarker;

    public int[,] Visited = new int[38, 20];
    public int[,] Blockade = new int[38, 20];

    int PosX;
    int PosZ;

    // Use this for initialization
    void Start()
    {

        SceneController scenecontroller = SceneController.GetComponent<SceneController>();
        Blockade = scenecontroller.Blockade;

    }

    // Update is called once per frame
    void Update()
    {

        PosX = (int)(gameObject.transform.position.x);
        PosZ = (int)(gameObject.transform.position.z);

        if (VisitCheck())
        {

            Instantiate(VisitMarker, new Vector3(PosX, 1, PosZ), Quaternion.identity);

        }

    }

    private void OnTriggerEnter(Collider coll)
    {

        //If player collides with terrain, halts movement and subtracts health
        if (coll.gameObject.tag == "Goal")
        {

            Destroy(gameObject);

        }

    }

    bool HasNeighbour()
    {

        if (Blockade[PosX + 1, PosZ] != 1 && Visited[PosX + 1, PosZ] != 1 || Blockade[PosX, PosZ + 1] != 1 && Visited[PosX, PosZ + 1] != 1 || Blockade[PosX - 1, PosZ] != 1 && Visited[PosX - 1, PosZ] != 1 || Blockade[PosX, PosZ - 1] != 1 && Visited[PosX, PosZ - 1] != 1)
        {

            return true;

        }
        else
        {

            return false;

        }

    }

    bool VisitCheck()
    {
        if (Visited[PosX, PosZ] != 1)
        {

            Visited[PosX, PosZ] = 1;
            return true;

        }
        else
        {

            return false;

        }

    }

}
