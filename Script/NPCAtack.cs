using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAtack : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public float attackDamage = 5f;
    public float attackCooldown = 1f;

    private Animator anim;
    private float lastAttackTime;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= attackRange) {
            if (Time.time > lastAttackTime + attackCooldown) {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    void AttackPlayer() {
        anim.SetTrigger("Attack"); // Asegúrate de tener una animación de ataque con este trigger.
        player.GetComponent<PlayerHealth>().TakeDamage((int)attackDamage);
    }
}
