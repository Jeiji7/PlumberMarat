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
        if (Input.GetKeyDown(KeyCode.J))
        {
            Molot.SetActive(true);
            activeAttack = true;
            MarioAnim.SetBool("AttackActive", true);
            MolotAnim.SetBool("Active",true);
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            activeAttack = false;
            MarioAnim.SetFloat("AttackMoveMario", 0);
            MarioAnim.SetBool("AttackActive", false);
            MolotAnim.SetBool("Active", false);
            Molot.SetActive(false);
        }
    }
}
