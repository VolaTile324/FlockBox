﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(MovementSystemGroup))]
[UpdateAfter(typeof(AccelerationSystem))]
public class VelocitySystem : JobComponentSystem
{
    [BurstCompile]
    struct VelocityJob : IJobForEach<Translation, AgentData>
    {
        public float dt;


        public void Execute(ref Translation c0, ref AgentData c1)
        {
            c1.Position += c1.Velocity * dt;
            c0.Value = c1.Position;
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        VelocityJob job = new VelocityJob
        {
            //pass input data into the job
            dt = Time.deltaTime
        };
        return job.Schedule(this, inputDeps);
    }
}
