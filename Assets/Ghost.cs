using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public GameObject PossessedEnemySlot;
    private Rigidbody2D rigidbody;
    Animator animator;

    float deadTimer;
    public float timeToDie;
    public SpriteRenderer SpriteRenderer;

    bool possessionAnimationFinished = false;

    private void Start()
    {
        deadTimer = timeToDie;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        deadTimer -= Time.deltaTime;
        SpriteRenderer.color = new Color(1, 1, 1, deadTimer / timeToDie);
        if(deadTimer <= 0)
        {
            //SceneManager.LoadScene(1);
            Application.LoadLevel("SampleScene");
        }
    }

    public void Possess(GameObject possessedPrefab, GameObject oldEnemy)
    {
        animator.SetTrigger("Possession");
        StartCoroutine(EndPossession(possessedPrefab, oldEnemy));
        deadTimer = timeToDie;


    }

    IEnumerator EndPossession(GameObject possessedPrefab, GameObject oldEnemy)
    {
        yield return new WaitUntil(()=>possessionAnimationFinished == true);
        gameObject.SetActive(false);

        GameObject x = Instantiate(possessedPrefab, PossessedEnemySlot.transform);
        x.GetComponent<PossessedEnemy>().Initialize(gameObject, oldEnemy.GetComponent<Health>());
        oldEnemy.SetActive(false);
        x.transform.position = oldEnemy.transform.position;
        x.transform.rotation = oldEnemy.transform.rotation;
        Destroy(oldEnemy);
        possessionAnimationFinished = false;

    }


    public void EndPossessionAnimationEvent()
    {
        possessionAnimationFinished = true;
    }



    public void Unpossess()
    {
        gameObject.SetActive(true);
        AddImpulseUpToGhost();
    }

    private void AddImpulseUpToGhost()
    {
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

        StartCoroutine(WaitOneSecond());

    }

    IEnumerator WaitOneSecond()
    {

        yield return new WaitForSeconds(0.5f);
        RemoveForceFromGhost();

    }

    private void RemoveForceFromGhost()
    {
        rigidbody.gravityScale = 8f;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.gravityScale = 0f;
    }


}
