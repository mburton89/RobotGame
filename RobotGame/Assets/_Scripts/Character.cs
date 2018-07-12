using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour {

	public static Character Instance;

	public Rigidbody2D rigidBody2d;

	private bool _isInMeleeMode;
	private bool _canSwitchWeapons;
	private bool _canShoot;
	private bool _triggerIsHeld;

	public List<Gun> guns;
	private int _gunIndex;
	public Gun activeGun;

	public List<MeleeWeapon> meleeWeapon;
	private int _meleeWeaponIndex;
	public MeleeWeapon activeMeleeWeapon;

	void Awake(){
		Instance = this;
	}

	void Start(){
		_canShoot = true;
		SetupRangedMode();
		GameplayHud.Instance.activeWeaponText.text = activeGun.gameObject.name;
	}

	void Update () {    
		Vector3 newVelocity = new Vector3(Input.GetAxis("LeftJoystickHorizontal"), -Input.GetAxis("LeftJoystickVertical"), 0);
		newVelocity *= 10f;
		rigidBody2d.velocity = newVelocity;

		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x,
			transform.eulerAngles.y, 
			Mathf.Atan2(-Input.GetAxis("RightJoystickHorizontal"), -Input.GetAxis("RightJoystickVertical")) * Mathf.Rad2Deg);


		if(Input.GetButtonDown(ButtonMappings.SwapStance)){
			SwitchCombatMode();
		}
			
		if(Input.GetAxis("RightTrigger") > 0.5f){

			if(_canShoot){
				if(_isInMeleeMode){
					MeleeAttack();
				}
				else{
					PullTrigger();
				}
			}
		}else{
			if(_triggerIsHeld){
				LetGoOfTrigger();
			}
		}

		if(Input.GetAxis("DPadHorizontal") < -0.5f){
			if(_canSwitchWeapons){
				SelectPreviousWeapon();
			}
		}else if(Input.GetAxis("DPadHorizontal") > 0.5f){
			if(_canSwitchWeapons){
				SelectNextWeapon();
			}
		}else{
			_canSwitchWeapons = true;
		}

	}

	public void PullTrigger(){
		activeGun.HandleTriggerPressed();
		_canShoot = false;
		_triggerIsHeld = true;
	}

	public void LetGoOfTrigger(){
		activeGun.HandleTriggerLetGo();
		_canShoot = true;
		_triggerIsHeld = false;
	}

	public void MeleeAttack(){
		activeMeleeWeapon.Attack();
	}

	public void SwitchCombatMode(){
		if(_isInMeleeMode){
			SetupRangedMode();
		}else{
			SetupMeleeMode();
		}
	}

	public void SetupRangedMode(){
		_isInMeleeMode = false;
		activeGun.gameObject.SetActive(true);
		activeMeleeWeapon.gameObject.SetActive(false);
		GameplayHud.Instance.combatModeText.text = "Ranged";
		GameplayHud.Instance.activeWeaponText.text = activeGun.gameObject.name;
	}

	public void SetupMeleeMode(){
		_isInMeleeMode = true;
		activeGun.gameObject.SetActive(false);
		activeMeleeWeapon.gameObject.SetActive(true);
		activeMeleeWeapon.canAttack = true;
		GameplayHud.Instance.combatModeText.text = "Melee";
		GameplayHud.Instance.activeWeaponText.text = activeMeleeWeapon.gameObject.name;
	}

	public void SelectPreviousWeapon(){
		if(_isInMeleeMode){
			activeMeleeWeapon.gameObject.SetActive(false);
			if(activeMeleeWeapon == meleeWeapon[0]){
				activeMeleeWeapon = meleeWeapon[1];
			}else{
				activeMeleeWeapon = meleeWeapon[0];
			}
			activeMeleeWeapon.gameObject.SetActive(true);
			GameplayHud.Instance.activeWeaponText.text = activeMeleeWeapon.gameObject.name;
		}else{
			activeGun.gameObject.SetActive(false);
			if(activeGun == guns[0]){
				activeGun = guns[1];
			}else{
				activeGun = guns[0];
			}
			activeGun.gameObject.SetActive(true);
			GameplayHud.Instance.activeWeaponText.text = activeGun.gameObject.name;
		}
		_canSwitchWeapons = false;
	}

	public void SelectNextWeapon(){
		if(_isInMeleeMode){
			activeMeleeWeapon.gameObject.SetActive(false);
			if(activeMeleeWeapon == meleeWeapon[0]){
				activeMeleeWeapon = meleeWeapon[1];
			}else{
				activeMeleeWeapon = meleeWeapon[0];
			}
			activeMeleeWeapon.gameObject.SetActive(true);
			GameplayHud.Instance.activeWeaponText.text = activeMeleeWeapon.gameObject.name;
		}else{
			activeGun.gameObject.SetActive(false);
			if(activeGun == guns[0]){
				activeGun = guns[1];
			}else{
				activeGun = guns[0];
			}
			activeGun.gameObject.SetActive(true);
			GameplayHud.Instance.activeWeaponText.text = activeGun.gameObject.name;
		}
		_canSwitchWeapons = false;
	}
}
