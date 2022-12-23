using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RoomTrigger;

public class RoomPoint : MonoBehaviour
{
    public DirectionPoint Direction_Point;

    public enum DirectionPoint
    {
        center,
        top_left,
        top_right,
        top,
        left,
        right,
        bottom,
        bottom_left,
        bottom_right,
    }
}
