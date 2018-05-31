﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Reorderable;

public class NestedExample : MonoBehaviour
{

    [Reorderable]
    public ExampleChildList list;

    [System.Serializable]
    public class ExampleChild
    {

        [Reorderable]
        public NestedChildList nested;
    }

    [System.Serializable]
    public class NestedChild
    {

        public float myValue;
    }

    [System.Serializable]
    public class ExampleChildList : ReorderableArray<ExampleChild>
    {
    }

    [System.Serializable]
    public class NestedChildList : ReorderableArray<NestedChild>
    {
        
    }
}
