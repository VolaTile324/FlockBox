﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(SteeringSystemGroup))]
public class AccelerationSystem : JobComponentSystem
{
    //what does a flocksystem need to make decisions about how an agents data should change
    //surroundings
    //settings, list of behaviors
    //
    [BurstCompile]
    //[RequireComponentTag(typeof(AgentTag))] //only look for 
    struct AccelerationJob : IJobForEach<Velocity, Acceleration>
    {
        public float dt;


        public void Execute(ref Velocity vel, ref Acceleration accel)
        {
            vel.Value += accel.Value * dt;
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        AccelerationJob job = new AccelerationJob
        {
            //pass input data into the job
            dt = Time.deltaTime
        };
        return job.Schedule(this, inputDeps);
    }
}
