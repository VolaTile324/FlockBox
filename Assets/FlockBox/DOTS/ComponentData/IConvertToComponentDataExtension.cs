﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.Entities;
using UnityEditor;
using UnityEngine;

public static class IConvertToComponentDataExtension
{
    public static void AddEntityData<T>(this IConvertToComponentData<T> value, Entity entity, EntityManager entityManager) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        entityManager.AddComponentData<T>(entity, value.Convert());
    }
    public static void AddEntityData<T>(this IConvertToComponentData<T> value, EntityQuery query, EntityManager entityManager) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        entityManager.AddChunkComponentData<T>(query, value.Convert());
    }
    public static void SetEntityData<T>(this IConvertToComponentData<T> value, Entity entity, EntityManager entityManager) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        entityManager.SetComponentData<T>(entity, value.Convert());
    }
    public static void RemoveEntityData<T>(this IConvertToComponentData<T> value, EntityQuery query, EntityManager entityManager) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        entityManager.RemoveChunkComponentData<T>(query);
    }
    public static void RemoveEntityData<T>(this IConvertToComponentData<T> value, Entity entity, EntityManager entityManager) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        entityManager.RemoveComponent<T>(entity);
    }
    public static void EntityCommandBufferAdd<T>(this IConvertToComponentData<T> value, Entity entity, EntityCommandBuffer buf) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        buf.AddComponent<T>(entity);
    }

    public static void EntityCommandBufferRemove<T>(this IConvertToComponentData<T> value, Entity entity, EntityCommandBuffer buf) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        buf.RemoveComponent<T>(entity);
    }

    public static void EntityCommandBufferSet<T>(this IConvertToComponentData<T> value, Entity entity, EntityCommandBuffer buf) where T : struct, IComponentData, ISteeringBehaviorComponentData
    {
        buf.SetComponent<T>(entity, value.Convert());
    }

}
