using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//enem _u can use to add like diifferent status or different positions or whatever
public enum VoxelState { Dead, Alive }




public class Voxel
{
    private Vector3Int _index;
    private GameObject _goVoxel;
    private VoxelState _status = VoxelState.Alive;


    //here use getters and setters   to  execute when you get variable    advantage of using get and set is that we can add some side effects.
    public VoxelState Status     //try to access the information that is inside status, it will run the code below 
    {
        get
        {
            return _status;                    //use my private fields
        }
        set
        {
            _goVoxel.SetActive(value == VoxelState.Alive);
            _status = value;
        }
    }



    public Voxel(Vector3Int index, GameObject goVoxelPrefab)
    {
        _index = index;
        _goVoxel = GameObject.Instantiate(goVoxelPrefab, _index, Quaternion.identity);  //Quaternion add rotation
        _goVoxel.GetComponent<VoxelTrigger>().TriggerVoxel = this;
    }


}

