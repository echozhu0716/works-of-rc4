using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voxelgrids : MonoBehaviour
{
    [SerializeField]    // means the fied is accessible with unity
    private Vector3Int GridDimension = new Vector3Int(16, 26, 6);

    private Voxel[,,] _voxels;
    private GameObject _goVoxelPrefab;


    // Start is called before the first frame update
    void Start()
    {
        _goVoxelPrefab = Resources.Load("prefabs/VoxelCube") as GameObject;
        CreatevoxelGrids();

        /*dog barry = new dog("Barry", "My dog");
        dog eddie = new dog("Eddie", "His dog");


        barry.Bark(6);
        eddie.Bark(2);*/




    }

    private void CreatevoxelGrids()

    {
        _voxels = new Voxel[GridDimension.x, GridDimension.y, GridDimension.z];  // how big is your area  how many elements are there

        for (int x = 0; x < GridDimension.x; x++)
        {
            for (int y = 0; y < GridDimension.y; y++)
            {
                for (int z = 0; z < GridDimension.z; z++)
                {
                    _voxels[x, y, z] = new Voxel(new Vector3Int(x, y, z), _goVoxelPrefab);  // literal index, loop over all the analysis -element in loop
                }
            }
        }

    }


        // Update is called once per frame

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                HandleRaycast();
            }

        }


        private void HandleRaycast()
        {
            Debug.Log("Clicked");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //then let the ray hit sth
        if(Physics.Raycast(ray,out RaycastHit hit))
        {

            // transform-everyobject has a transform to get them in space

           Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Voxel"))
            {
                // Destroy(objectHit.gameObject);
                StartCoroutine(Dead());
            }

            IEnumerator Dead()
            {
                objectHit.gameObject.SetActive(false);
                yield return new WaitForSeconds(5);
                objectHit.gameObject.SetActive(true );

            }
              
                    
                    
                    
                    // objectHit.gameObject.GetComponent<VoxelTrigger>().TriggerVoxel.Status = VoxelState.Dead;

            }
        }

        }


    

}


