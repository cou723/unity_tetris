using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnMino : MonoBehaviour
{
    public GameObject[] Minos;
    private List<int> AlreadyMinos = new List<int>();
    private Queue<int> Nexts = new Queue<int>();
    // Start is called before the first frame update
    void Start()
    {
        NewMino();
    }

    public void NewMino()
    {
        FillNexts();
        int mino_index = Nexts.Dequeue();
        Instantiate(Minos[mino_index], GetSpawnPos(mino_index), Quaternion.identity);
            Debug.Log($"{String.Join(", ", Nexts)}, ");
    }
    private void FillNexts()
    {
        while (Nexts.Count <= 6)
            Nexts.Enqueue(CreateMinoIndex());
    }

    private void UpdateAlreadyMinos()
    {
        if (AlreadyMinos.Count >= 7)
            AlreadyMinos = new List<int>();
    }

    private int CreateMinoIndex()
    {
        UpdateAlreadyMinos();
        int mino_index = UnityEngine.Random.Range(0, Minos.Length);
        while (AlreadyMinos.Contains(mino_index))
            mino_index = UnityEngine.Random.Range(0, Minos.Length);
        AlreadyMinos.Add(mino_index);
        return mino_index;
    }

    private Vector3 GetSpawnPos(int mino_index)
    {
        Vector3 spawnPos = transform.position;
        if (mino_index <= 4)
        {
            spawnPos += new Vector3(0.5f, 0, 0);
        }
        else
        {
            spawnPos += new Vector3(0, 0.5f, 0);
        }
        return spawnPos;
    }
}
