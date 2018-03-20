using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource SoundSource;

	public AudioClip 	PreGameSound;
	public AudioClip 	MainGameSound;
	public AudioClip 	BumperHitSound;
	public AudioClip 	BounceWallSound;
	public AudioClip 	BossHitSound;
	public AudioClip 	BossUltiSound;
	public AudioClip 	DeathSound;
	public AudioClip 	HandHitSound;
	public AudioClip 	ShooterSound;
	public AudioClip 	StarSound;
	public AudioClip 	WellAppearSound;


	// Use this for initialization
	void Start () {
		SoundSource.clip = PreGameSound;
		SoundSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PlayBumperHit(){
		SoundSource.PlayOneShot (BumperHitSound);
	}

	public void PlayBounceWall(){
		SoundSource.PlayOneShot (BounceWallSound);
	}

	public void PlayBossHit(){
		SoundSource.PlayOneShot (BossHitSound);
	}

	public void PlayBossUlti(){
		SoundSource.PlayOneShot (BossUltiSound);
	}

	public void PlayDeath(){
		SoundSource.PlayOneShot (DeathSound);
	}

	public void PlayHandHit(){
		SoundSource.PlayOneShot (HandHitSound);
	}

	public void PlayMainSoundLoop() {
		SoundSource.Stop ();
		SoundSource.clip = MainGameSound;
		SoundSource.volume = 0.3f;
		SoundSource.Play();
	}

	public void PlayShooter() {
		SoundSource.PlayOneShot (ShooterSound);
	}

	public void PlayStar() {
		SoundSource.PlayOneShot (StarSound);
	}

	public void PlayWellAppear(){
		SoundSource.PlayOneShot (WellAppearSound);
	}
}
