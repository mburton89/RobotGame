using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public enum GunType{
		TapToShoot,
        TapAndHold,
        TapTwice
	}

	public GunType gunType;
    
	[SerializeField] private Ammo _ammoPrefab;
	private Ammo _activeAmmo;

	public int shootingSpeed;
    public int timeToDestroy;

	private bool _hasServedAmmo;

	public void HandleTriggerPressed()
    {
		if (gunType == GunType.TapTwice)
        {
			if (_hasServedAmmo)
			{
				Fire();
				_hasServedAmmo = false;
				StopCoroutine("DetermineServe");
				return;
			}
			else
			{
				StartCoroutine("DetermineServe");
			}
        }

		_activeAmmo = Instantiate(_ammoPrefab);
		_activeAmmo.transform.SetParent(this.transform);
		_activeAmmo.transform.position = this.transform.position;
		_activeAmmo.transform.rotation = transform.rotation;

		if(gunType == GunType.TapToShoot){
			Fire();
		}
    }

    public void HandleTriggerLetGo()
    {
		if (gunType == GunType.TapAndHold)
        {
            Fire();
        }
    }

    void Fire()
    {
		_activeAmmo.rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
		_activeAmmo.transform.SetParent(Root.Instance.transform);
		_activeAmmo.rigidBody2D.AddForce(transform.TransformDirection(Vector3.up) * shootingSpeed);
		Destroy(_activeAmmo.gameObject, timeToDestroy);
    }

	private IEnumerator DetermineServe(){
		_hasServedAmmo = true;
		yield return new WaitForSeconds(2);
		_hasServedAmmo = false;
		Destroy(_activeAmmo.gameObject);
	}
}
