using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pool : MonoBehaviour
{
    public static Pool Instance { get; private set; }
    public GameObject Bala;
    public int cantidadIm;

    List<GameObject> pool = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
        FillPool();
    }
    void FillPool()
    {
        for (int i = 0; i < cantidadIm; i++)
        {
            GameObject go = Instantiate(Bala);
            go.SetActive(false);
            pool.Add(go);
        }
    }
    public GameObject Get()
    {
        GameObject ret;
        if (pool.Count > 0)
        {
            ret = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);
        }
        else { ret = Instantiate(Bala);}
        ret.SetActive(true);
        return ret;
    }
    public void Return(GameObject go)
    {
        go.SetActive(false);
        pool.Add(go);
    }
}
