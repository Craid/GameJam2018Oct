using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour {


	private AudioSource _audioSource;

	public AudioClip engineStartClip;
	public AudioClip engineLoopClip;
	void Start()
	{
		_audioSource = GetComponent<AudioSource> ();
		StartCoroutine(playEngineSound());
		DontDestroyOnLoad(transform.gameObject);
	}

	IEnumerator playEngineSound()
	{
		_audioSource.clip = engineStartClip;
		_audioSource.Play();
		yield return new WaitForSeconds(_audioSource.clip.length);
		_audioSource.clip = engineLoopClip;
		_audioSource.Play();
	}

	public void PlayMusic(){
		_audioSource.Play ();
	}

	public void StopMusic(){
		_audioSource.Stop ();
	}
		
}