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
            Walk(); // Volání metody Walk pro aktivování animaci chůze
        }
        else
        {
            isWalking = false;
        }

        // Kontrola pro útok
        if (Input.GetMouseButtonDown(0)) // Odebrána kontrola, zda hráč může střílet
        {
            
            Attack();
        }
    }

    public void Attack()
    {
        // Spuštění animace útoku
        animator.SetTrigger("Attack");
    }

    public void Walk()
    {
        // Aktivace animaci chůze

    }
}