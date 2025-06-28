using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Rigidbody[] cubes;
    public int correctIndex;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    private bool hasPlayed = false;

    public void OnCubeSelected(int index)
    {
        if (hasPlayed) return;
        hasPlayed = true;

        for (int i = 0; i < cubes.Length; i++)
        {
            if (i == correctIndex)
            {
                cubes[i].useGravity = false;
                cubes[i].isKinematic = true;
            }
            else
            {
                cubes[i].useGravity = true;
            }
        }

        if (index == correctIndex)
        {
            winText.gameObject.SetActive(true);
        }
        else
        {
            loseText.gameObject.SetActive(true);
        }
    }
}
