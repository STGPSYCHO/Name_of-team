using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static RoomPoint;

public class RoomTrigger : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> room;

    public List<Map> Maps;
    public List<GameObject> MapsObj;
    public List<RoomPoint> RoomPointsCenters;
    private bool isTouchingCenter;
    
    public RoomPoint[] RoomPoints;
    public DirectionTrigger Direction_Trigger;
    public enum DirectionTrigger
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
        GameObject parent = transform.root.gameObject;
        RoomPoints = parent.GetComponentsInChildren<RoomPoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int a = 0;
        if (UnityEngine.Random.value >= 0.5f) { a = 1; }
        Debug.Log(a);
        GetAllCenterPoints();
        if (Direction_Trigger == DirectionTrigger.Left)
        {
            foreach (RoomPoint roomPoint in RoomPoints)
            {
                if (roomPoint == null)
                {
                    continue;
                }
                if (roomPoint.Direction_Point == DirectionPoint.top_left || roomPoint.Direction_Point == DirectionPoint.left||
                    roomPoint.Direction_Point == DirectionPoint.bottom_left)
                {
                    foreach (RoomPoint rp in RoomPointsCenters)
                    {
                        if (roomPoint.GetComponent<BoxCollider2D>().IsTouching(rp.GetComponent<BoxCollider2D>()))
                        {
                            isTouchingCenter = true;
                        }
                    }
                    if (isTouchingCenter)
                    {
                        isTouchingCenter=false;
                        continue;
                    }
                    else
                    {
                        Instantiate(room[a], roomPoint.transform.position, roomPoint.transform.rotation);
                    }
                    
            
                }
            }
        }
        if (Direction_Trigger == DirectionTrigger.Top)
        {
            foreach (RoomPoint roomPoint in RoomPoints)
            {
                if (roomPoint == null)
                {
                    continue;
                }
                if (roomPoint.Direction_Point == DirectionPoint.top_left || roomPoint.Direction_Point == DirectionPoint.top ||
                    roomPoint.Direction_Point == DirectionPoint.top_right)
                {
                    foreach (RoomPoint rp in RoomPointsCenters)
                    {
                        if (roomPoint.GetComponent<BoxCollider2D>().IsTouching(rp.GetComponent<BoxCollider2D>()))
                        {
                            isTouchingCenter = true;
                        }
                    }
                    if (isTouchingCenter)
                    {
                        isTouchingCenter = false;
                        continue;
                    }
                    else
                    {
                        Instantiate(room[a], roomPoint.transform.position, roomPoint.transform.rotation);
                    }
                }
            }
        }
        if (Direction_Trigger == DirectionTrigger.Right)
        {
            foreach (RoomPoint roomPoint in RoomPoints)
            {
                if (roomPoint == null)
                {
                    continue;
                }
                if (roomPoint.Direction_Point == DirectionPoint.top_right || roomPoint.Direction_Point == DirectionPoint.right ||
                    roomPoint.Direction_Point == DirectionPoint.bottom_right)
                {
                    foreach (RoomPoint rp in RoomPointsCenters)
                    {
                        if (roomPoint.GetComponent<BoxCollider2D>().IsTouching(rp.GetComponent<BoxCollider2D>()))
                        {
                            isTouchingCenter = true;
                        }
                    }
                    if (isTouchingCenter)
                    {
                        isTouchingCenter = false;
                        continue;
                    }
                    else
                    {
                        Instantiate(room[a], roomPoint.transform.position, roomPoint.transform.rotation);
                    }


                }
            }
        }
        if (Direction_Trigger == DirectionTrigger.Bottom)
        {
            foreach (RoomPoint roomPoint in RoomPoints)
            {
                if (roomPoint == null)
                {
                    continue;
                }
                if (roomPoint.Direction_Point == DirectionPoint.bottom || roomPoint.Direction_Point == DirectionPoint.bottom_right ||
                    roomPoint.Direction_Point == DirectionPoint.bottom_left)
                {
                    foreach (RoomPoint rp in RoomPointsCenters)
                    {
                        if (roomPoint.GetComponent<BoxCollider2D>().IsTouching(rp.GetComponent<BoxCollider2D>()))
                        {
                            isTouchingCenter = true;
                        }
                    }
                    if (isTouchingCenter)
                    {
                        isTouchingCenter = false;
                        continue;
                    }
                    else
                    {
                        Instantiate(room[a], roomPoint.transform.position, roomPoint.transform.rotation);
                    }


                }
            }
        }

        foreach(RoomPoint roomPoint in RoomPointsCenters)
        {
            if ((player.transform.position - roomPoint.transform.position).magnitude > 100)
            {
                roomPoint.transform.root.GetComponent<DestroyModule>().ActivateModule();
            }
        }
    }

    private void GetAllCenterPoints()
    {
        Maps.Clear();
        MapsObj.Clear();
        RoomPointsCenters.Clear();
        Maps = FindObjectsOfType<Map>().ToList<Map>();
        foreach (Map map in Maps)
        {
            MapsObj.Add(map.transform.root.gameObject);
        }
        foreach (GameObject map in MapsObj)
        {
            foreach (RoomPoint roomp in map.GetComponentsInChildren<RoomPoint>())
            {
                if (roomp.Direction_Point == DirectionPoint.center)
                {
                    RoomPointsCenters.Add(roomp);
                }
            }
        }
    }

}
