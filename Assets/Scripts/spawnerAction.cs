using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnerAction : MonoBehaviour
{
    public float width = 10f;
    public float height = 5f;
    public GameObject pianoTile;
    public float delay = 0.5f;
    public float min = -5f;
    public float max = 10f;

    void Start()
    {
        spawnUntil();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    void Update()
    {
        if (checkForEmpty())
        {
            spawnUntil();
        }
    }
    void spawnUntil()
    {
        Transform position = freePosition();
        float rand = Random.Range(min, max);
        Vector3 offset = new Vector3(0, rand, 0);

        if (position)
        {
            GameObject piano = Instantiate(pianoTile, position.transform.position + offset, Quaternion.identity);
            piano.transform.parent = position;

            // columnIndex deðerini belirle
            int columnIndex = position.GetSiblingIndex() + 1; // Sütun indeksini 1, 2, 3 olarak alýr
            piano.GetComponent<tileAction>().columnIndex = columnIndex;

            tileAction tile = piano.GetComponent<tileAction>();
            if(Random.Range(0, 100) < 20) // %20 olasýlýkla gelicek 
            {
                tile.IsObstacle = true;
                tile.color.color = Color.black; // Engelleri siyah renkle göster
                tile.scoreValue = -5; // Engel tuþuna basýldýðýnda puan kaybý
            }
        }

        if(freePosition())
        {
            Invoke("spawnUntil", delay);
        }
    }
    void Spawner()
    {
        foreach (Transform child in transform)
        {
            GameObject piano = Instantiate(pianoTile, child.position, Quaternion.identity);
            piano.transform.parent = child;
        }
    }

    bool checkForEmpty()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform freePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }
}
