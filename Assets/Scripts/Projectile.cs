using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public LayerMask collisionMask;
	float speed = 10;
	float damage = 1;

	float lifetime = 3;
	float skinWidth = .1f;

	void Start() {
		Destroy (gameObject, lifetime);

		Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
		if (initialCollisions.Length > 0) {
			OnHitObject(initialCollisions[0]);
		}
	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	} 

	void Update () {
		float moveDistance = speed * Time.deltaTime ;
		CheckCollisions (moveDistance);
		transform.Translate (Vector3.forward * moveDistance);
	}

	void CheckCollisions(float moveDistance) {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide)) {
			OnHitObject(hit);
		}
	}

	void OnHitObject(RaycastHit hit) {
		IDamageable damagebleObject = hit.collider.GetComponent<IDamageable> ();
		if (damagebleObject != null) {
			damagebleObject.TakeHit(damage, hit);
		}

		GameObject.Destroy (gameObject);
	}

	void OnHitObject(Collider c) {
		IDamageable damagebleObject = c.GetComponent<IDamageable> ();
		if (damagebleObject != null) {
			damagebleObject.TakeDamage(damage);
		}
		
		GameObject.Destroy (gameObject);
	}
}
