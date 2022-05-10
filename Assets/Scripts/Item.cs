﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Item : ScriptableObject
{

    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite ItemIcon;
    [Range(1,999)]
    public int MaximumStack = 1;


    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual Item Destroy()
    {
        Destroy(this);
        return this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}