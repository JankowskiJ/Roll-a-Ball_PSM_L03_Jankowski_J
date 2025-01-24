using System.Collections;
using TMPro;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private int deathCount;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = new Vector3(5, 0.5f, 1);
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<DeathController>().DeathEvent += PlayerDied;
    }
    private void PlayerDied()
    {
        deathCount++;
        player.GetComponent<Rigidbody>().Sleep();
        player.GetComponent<SphereCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<MovementController>().isDead = true;
        player.GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<AudioSource>().Play();
        player.GetComponent<ParticleSystem>().Play();
        StartCoroutine(RespawnPlayerAfterDelay());
    }
    private IEnumerator RespawnPlayerAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        player.GetComponent<Transform>().position = startPosition;
        player.GetComponent<MovementController>().isDead = false;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<SphereCollider>().enabled = true;
    }
}
