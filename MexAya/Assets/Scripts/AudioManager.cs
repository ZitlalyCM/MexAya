using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;
	public static List<SONG> allSongs = new List<SONG>();
	public static SONG activeSong = null;
	public float songTransitionSpeed = 1f;
	public bool songSmoothTransitions = true;

	void Awake(){
		//si se carga una escena posterior, elimina el nuevo y 
		//deja el anterior que no se destruyo continuar
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			DestroyImmediate(gameObject);
		}
	}

	public void PlaySFX(AudioClip effect, float volume = 1f, float pitch = 1f){
		AudioSource source = CreateNewAudioSource(string.Format("SFX [{0}]", effect.name));
		source.clip = effect;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
		Destroy(source.gameObject,effect.length);
	}

	public static AudioSource CreateNewAudioSource(string _name){
		AudioSource nuevo = new GameObject(_name).AddComponent<AudioSource>();
		nuevo.transform.SetParent(instance.transform);
		return nuevo;
	}

	public void PlaySong(AudioClip song, float maxVolume = 1f,float pitch = 1f, float startingVolume=0,bool playOnStart=true,bool loop = true){
		//busca el audio clip en la lista de canciones, si existe la convierte en la cancion activa
		//si se manda un null en audioclip para la cancion
		//si la cancion no existe, la crea y la convierte en la cancion activa
		if(song != null){
			for(int i = 0; i < allSongs.Count; i++){
				SONG s = allSongs[i];
				if(s.clip == song){
					activeSong = s;
					break;
				}
			}
			if(activeSong==null || activeSong.clip != song){
				//si no existe (null si es la primera, o mantiene la cancion anterior)
				activeSong = new SONG(song,maxVolume, pitch, startingVolume, playOnStart,loop);
			}

		}else{
			activeSong = null;
		}
		StopAllCoroutines();
		StartCoroutine(volumeLeveling());
	}

	IEnumerator volumeLeveling(){
		while(transitionSongs()){
			yield return new WaitForEndOfFrame();
		}
	}

	bool transitionSongs(){
		bool anyValueChanged = false;

		float speed = songTransitionSpeed * Time.deltaTime;
		for (int i = allSongs.Count - 1; i >= 0; i--) 
		{
			SONG song = allSongs [i];
			if (song == activeSong) 
			{
				if (song.volume < song.maxVolume) 
				{
					song.volume = songSmoothTransitions ? Mathf.Lerp (song.volume, song.maxVolume, speed) : Mathf.MoveTowards (song.volume, song.maxVolume, speed);
					anyValueChanged = true;
				}
			} 
			else 
			{
				if (song.volume > 0) 
				{
					song.volume = songSmoothTransitions ? Mathf.Lerp (song.volume, 0f, speed) : Mathf.MoveTowards (song.volume, 0f, speed);
					anyValueChanged = true;
				}
				else
				{
					allSongs.RemoveAt (i);
					song.DestroySong();
					continue;
				}
			}
		}

		return anyValueChanged;
	}

	[System.Serializable]
	public class SONG{
		public AudioSource source;
		public float maxVolume = 1f;
		public float volume {get{return source.volume;} set{source.volume = value;}}
		public float pitch {get{return source.pitch;} set{source.pitch = value;}}
		public AudioClip clip {get{return source.clip;} set {source.clip = value;}}

		public SONG(AudioClip clip, float _maxVolume,float pitch, float startingVolume, bool playOnStart, bool loop){
			source = AudioManager.CreateNewAudioSource(String.Format("SONG [{0}]",clip.name));
			source.clip = clip;
			source.volume = startingVolume;
			source.pitch = pitch;
			source.loop = loop;
			maxVolume = _maxVolume;
			AudioManager.allSongs.Add(this);

			if(playOnStart){
				source.Play();
			}
		}

		public void Play(){
			source.Play();
		}

		public void Stop(){
			source.Stop();
		}

		public void Pause(){
			source.Pause();
		}

		public void UnPause(){
			source.UnPause();
		}

		public void DestroySong(){
			AudioManager.allSongs.Remove(this);
			DestroyImmediate(source.gameObject);
		}
	}

}

