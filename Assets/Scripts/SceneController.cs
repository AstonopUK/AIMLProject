using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    static int[,] GridMap = new int[38,20];
    static int[,] Blockade = new int[38, 20];

    public Rigidbody Cube;

    // Start is called before the first frame update
    void Start()
    {

        for (int z = 0; z <= 19; z++)
        {

            for (int x = 0; x <= 37; x++)
            {

                int rIntX = Random.Range(0, 4);

                if (rIntX == 1)
                {

                    Instantiate(Cube, new Vector3(x, 1, z), Quaternion.identity);
                    Blockade[x, z] = 1;

                }
                else
                {

                    Blockade[x, z] = 0;

                }

            }

        }



    }

    // Update is called once per frame
    void Update()
    {
        


    }

}
