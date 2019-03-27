using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMenu : MonoBehaviour
{

	private void Start() {
		if (Assets.Scripts.Globals.PeristentMusic != null) {
			Destroy(gameObject);
			return;
		}
		Assets.Scripts.Globals.PeristentMusic = transform.gameObject;
	}

	private AudioSource _audioSource;
	private void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		_audioSource = GetComponent<AudioSource>();
	}

	public void PlayMusic() {
		if (_audioSource.isPlaying) return;
		_audioSource.Play();
	}

	public void StopMusic() {
		_audioSource.Stop();
	}

}
