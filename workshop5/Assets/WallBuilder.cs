using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    public GameObject brickPrefab;
    public int width = 5;
    public int height = 3;
    public float spacing = 1.1f;

    void Start()
    {
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = transform.position + new Vector3(x * spacing, y * spacing, 0);
                Instantiate(brickPrefab, pos, Quaternion.identity);
            }
    }
}
