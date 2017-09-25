using UnityEngine.Audio;
using System;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;
	public AudioClip clip;

	[Range(0f,1f)]
	public float volume;

	public bool loop;

	[HideInInspector]
	public AudioSource source;
}

public class SoundManager : MonoBehaviour {

	public Sound[] sounds;

	void Awake () {

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip; 
			s.source.volume = s.volume;
			s.source.loop = s.loop;
		}
	}

	public void Play (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null)
			return;
		s.source.Play ();
	}
}
