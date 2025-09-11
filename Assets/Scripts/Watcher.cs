using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    Transform targ { get => PlayerSingleton.Instance.transform; }
    public bool alreadyAttacking = false;
    [ShowInInspector] bool watching = true;
    [SerializeField] bool canAttack = false;
    [SerializeField] float coolDownTime = 2f;
    [SerializeField] float watchTime = 5f;
    [SerializeField] private float speed = 1.2f;

    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(Watch());
    }

    private void Update()
    {
        if(!alreadyAttacking || watching)
            transform.LookAt(targ);

        if (!alreadyAttacking && canAttack && !watching)
            StartCoroutine(routine: Attack());

    }

    IEnumerator Watch()
    {
        watching = true;
        yield return new WaitForSeconds(watchTime + Random.Range(4, 10));
        watching = false;
    }

    IEnumerator Attack()
    {
        watching = false;
        alreadyAttacking = true;
        AttackFunctionality();
        yield return new WaitForSeconds(coolDownTime);
        alreadyAttacking = false;
        StartCoroutine(Watch());
    }

    void AttackFunctionality()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
