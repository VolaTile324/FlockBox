﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class FlockSystem : JobComponentSystem
{
    //what does a flocksystem need to make decisions about how an agents data should change
    //surroundings
    //settings, list of behaviors
    //
    [BurstCompile]
    //[RequireComponentTag(typeof(AgentTag))] //only look for 
    struct FlockJob : IJobForEach<Translation, Velocity>
    {
        public float dt;


        public void Execute(ref Translation c0, ref Velocity c1)
        {
            c0.Value += c1.Value * dt;
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        FlockJob job = new FlockJob
        {
            //pass input data into the job
            dt = Time.deltaTime
        };
        return job.Schedule(this, inputDeps);
    }
}
