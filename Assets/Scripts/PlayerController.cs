using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking = false;

    private void Start()
    {
        // Získání komponenty Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Kontrola, zda je hráč v pohybu
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        // Nastavení parametru pro Animator
        animator.SetBool("IsWalking", isWalking);

        // Kontrola pro útok
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        // Spuštění animace útoku
        animator.SetTrigger("Attack");
    }
}