using UnityEngine;

public class playerMovementTest : MonoBehaviour
{
   public float health = 10f;
   private float attackTimer = 0f;
    public float attackCooldown = 2f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C)&& attackTimer <= 0f)
        {
            attackTimer = attackCooldown;
            health -= 1f;
            Debug.Log("Player attacked! Health: " + health);
        }

        if (health <= 0f)
        {
            Debug.Log("Player is dead!");
        }
    }

}
