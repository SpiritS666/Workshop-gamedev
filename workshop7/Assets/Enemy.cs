using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public float explodeForce = 500f;

    [SerializeField] private TextMeshProUGUI textScore;

    public GameObject destroySoundObject;
    private AudioSource audioSource;

    private void Start()
    {
        if (textScore != null)
            textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();

        if (destroySoundObject != null)
            audioSource = destroySoundObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(PlaySoundAndExplode());
            AddScore();
        }
    }

    private void AddScore()
    {
        Progress.Instance.AddScore(10); 

        if (textScore != null)
            textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
    }

    private IEnumerator PlaySoundAndExplode()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        SpawnPieces();

        gameObject.SetActive(false);

        if (audioSource != null)
            yield return new WaitForSeconds(audioSource.clip.length);
        else
            yield return null;

        if (destroySoundObject != null)
            Destroy(destroySoundObject);

        Destroy(gameObject);
    }

    private void SpawnPieces()
    {
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
                for (int z = 0; z < 4; z++)
                {
                    Vector3 piecePosition = transform.position + new Vector3(x, y, z) * 0.5f;
                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
                    if (pieceRigidbody != null)
                    {
                        pieceRigidbody.AddExplosionForce(explodeForce, transform.position, 5f);
                    }
                }
    }
}
