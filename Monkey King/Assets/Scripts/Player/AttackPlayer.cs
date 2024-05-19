using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Animator MarioAnim;
    public Animator MolotAnim;
    public GameObject Molot;
    public static bool activeAttack = false;

    private void Start()
    {
        activeAttack = false;
    }
    void Update()
    {
        if (MolotTrigger.ActiveMolot == true)
            StartCoroutine(Attack());
    }
    public IEnumerator Attack()
    {
        MarioAnim.SetFloat("isMoveAnim", 0);
        Molot.SetActive(true);
        activeAttack = true;
        MarioAnim.SetBool("AttackActive", true);
        MolotAnim.SetBool("Active", true);
        yield return new WaitForSeconds(15f);
        activeAttack = false;
        MarioAnim.SetFloat("AttackMoveMario", 0);
        MarioAnim.SetBool("AttackActive", false);
        MolotAnim.SetBool("Active", false);
        Molot.SetActive(false);
        MolotTrigger.ActiveMolot = false;
    }
}
