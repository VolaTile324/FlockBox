﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmptyBehavior : SteeringBehavior
{
    public int maxStatus = 100;

    public override Vector3 GetSteeringBehaviorVector(SteeringAgent mine, SurroundingsInfo surroundings)
    {
       
            return new Vector3(0, 0);
       
    }
}
