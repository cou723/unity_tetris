using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    public float previousTime;
    public float fallTime = 1f;

    // TODO: これここじゃなくてStageクラスとか作って管理したほうがよくない？
    private static int width = 10;
    private static int height = 20;
    public Vector3 rotationPoint;
    private static Transform[,] grid = new Transform[width, height];

    void Update()
    {
        MinoMovement();
    }
    private void MinoMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            TryToLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            TryToRight();
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - previousTime >= fallTime)
            TryToDown();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            TryRotate();
    }
    private void TryToRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!IsValidMovement()) transform.position -= new Vector3(1, 0, 0);
    }
    private void TryToLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!IsValidMovement()) transform.position -= new Vector3(-1, 0, 0);
    }
    private void TryToDown()
    {
        transform.position += new Vector3(0, -1, 0);
        if (!IsValidMovement())
        {
            transform.position -= new Vector3(0, -1, 0);
            AddToGrid();
            SetToGrid();
            LineClear();
            this.enabled = false;
            FindObjectOfType<SpawnMino>().NewMino();
        }
        previousTime = Time.time;
    }
    private void TryRotate()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
    }
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundY] = children;
        }
    }
    public void LineClear()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }
    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }

    }
    public void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    void SetToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundY] = children;
        }
    }
    bool IsValidMovement()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);
            if (roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
                return false;
            if (grid[roundX, roundY] != null)
                return false;
        }
        return true;
    }
}
