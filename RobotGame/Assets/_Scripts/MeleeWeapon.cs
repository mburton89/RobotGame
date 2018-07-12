using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MeleeWeapon : MonoBehaviour {

	public Rigidbody2D rigidBody2D;
	public BoxCollider2D boxCollider2D;

	public Transform pivot;

	public bool canAttack;

	public enum WeaponType{
		Stab,
		Swing
	}

	public WeaponType weaponType;

	public void Attack(){
		if(canAttack){
			canAttack = false;
			if(weaponType == WeaponType.Stab){
				transform.DOLocalMoveY(1,.25f, false).OnComplete(() => {
					transform.DOLocalMoveY(0,.25f, false).OnComplete(() => {
						canAttack = true;
					});
				});
			}else if(weaponType == WeaponType.Swing){
				Vector3 rotateAmount = new Vector3 (0,0,180);
				Vector3 negRotateAmount = new Vector3 (0,0,-180);
				pivot.transform.DORotate(rotateAmount,.25f,RotateMode.LocalAxisAdd).OnComplete(() => {
					pivot.transform.DORotate(negRotateAmount,.25f,RotateMode.LocalAxisAdd).OnComplete(() => {
						canAttack = true;
					});
				});
			}
		}
	}
}
