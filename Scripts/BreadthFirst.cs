using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirst : MonoBehaviour
{

    public GameObject SceneController;
    public GameObject VisitMarker;
    public GameObject PanicBrick;

    public int[,] Visited = new int[38, 20];
    public int[,] Blockade = new int[38, 20];

    int PosX;
    int PosZ;

    char Direction;

    public enum DIRECTIONS
    {

        UP = 'n',
        DOWN = 's',
        LEFT = 'w',
        RIGHT = 'e'

    };

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
        
        if (HasNeighbour())
        {

            switch (Direction)
            {

                case 'n':
                    gameObject.transform.position.x++;
                    break;
                case 's':
                    gameObject.transform.position.x--;
                    break;
                case 'e':
                    gameObject.transform.position.z++;
                    break;
                case 'w':
                    gameObject.transform.position.z--;
                    break;
                default:
                    break;

            }

        }
        else if (ReverseVisit())
        {

            switch (Direction)
            {

                case 'n':
                    gameObject.transform.position.x++;
                    break;
                case 's':
                    gameObject.transform.position.x--;
                    break;
                case 'e':
                    gameObject.transform.position.z++;
                    break;
                case 'w':
                    gameObject.transform.position.z--;
                    break;
                default:
                    break;

            }

        }
        else
        {

            Instantiate(PanicBrick, new Vector3(15, 3, 10), Quaternion.identity);
            Time.timescale = 0;

        }

        if (VisitCheck())
        {

            Instantiate(VisitMarker, new Vector3(PosX, 1, PosZ), Quaternion.identity);

        }

        yield return new WaitForSeconds(0.5);

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

        if (Blockade[PosX + 1, PosZ] != 1 && Visited[PosX + 1, PosZ] != 1)
        {

            Direction = UP;
            return true;

        }
        else if (Blockade[PosX, PosZ + 1] != 1 && Visited[PosX, PosZ + 1] != 1)
        {

            Direction = RIGHT;
            return true;

        }
        else if (Blockade[PosX - 1, PosZ] != 1 && Visited[PosX - 1, PosZ] != 1)
        {

            Direction = DOWN;
            return true;

        }
        else if (Blockade[PosX, PosZ - 1] != 1 && Visited[PosX, PosZ - 1] != 1)
        {

            Direction = LEFT;
            return true;

        }
        else
        {

            return false;

        }

    }

    bool ReverseVisit()
    {

        if (Blockade[PosX - 1, PosZ] != 1 && Visited[PosX - 1, PosZ] == 1)
        {

            Direction = DOWN;
            return true;

        }
        else if (Blockade[PosX, PosZ - 1] != 1 && Visited[PosX, PosZ - 1] == 1)
        {

            Direction = LEFT;
            return true;

        }
        else if (Blockade[PosX + 1, PosZ] != 1 && Visited[PosX + 1, PosZ] == 1)
        {

            Direction = UP;
            return true;

        }
        else if (Blockade[PosX, PosZ + 1] != 1 && Visited[PosX, PosZ + 1] == 1)
        {

            Direction = RIGHT;
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
