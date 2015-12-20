using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivingEntity : MonoBehaviour, IDamageable {

	public float startingHealth;
	public float health;
	public bool dead;

	public event System.Action OnDeath;

	public Slider healthSlider;

	protected virtual void Start() {
		health = startingHealth;
	}

	public void TakeHit(float damage, RaycastHit hit) {
		// Do some stuff here with the hit var
		TakeDamage (damage);
	}

	public void TakeDamage(float damage) {
		health -= damage;

		if (gameObject.name == "Player") {
			healthSlider.value = health;
		}

		if (health <= 0 && !dead) {

			if (gameObject.name == "Player") {
				Transform[] playerChilds = GetComponentsInChildren<Transform> ();

				foreach (Transform child in playerChilds) {
					child.GetComponent<Renderer> ().enabled = false;
				}
				GetComponent<Player> ().setShootFalse ();

				Application.LoadLevel ("Game");
			}
			else {
				Die();
			}
		}
	}

	public void Die() {
		dead = true;
		if (OnDeath != null) {
			OnDeath();
		}
		GameObject.Destroy (gameObject);
	}
}
