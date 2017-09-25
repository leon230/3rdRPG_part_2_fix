using UnityEngine;

public class CharacterStats : MonoBehaviour {


    public int maxHealth = 100;
    public int curentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public void Awake()
    {
        curentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        curentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage");

        if (curentHealth <= 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        Debug.Log("Died...");
    }

}
