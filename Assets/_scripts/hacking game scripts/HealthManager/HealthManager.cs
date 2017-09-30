using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour {

    public GameObject createOnDestroy;
    public int startingHealth = 100; // default starting health
    private int currentHealth;


	public UnityEvent zeroHealthEvent;

	// Use this for initialization
	void Start () {
        this.ResetHealthToStarting();
	}

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health lte zero, destroy the object
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0){
			
            //Destroy(this.gameObject);
			zeroHealthEvent.Invoke();

			/* IMPLEMENT PARTICLE EFFECTS LATER
            GameObject obj = Instantiate(this.createOnDestroy);
            obj.transform.position = this.transform.position;
            */
        }
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }
}
