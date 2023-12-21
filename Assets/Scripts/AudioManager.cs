using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    private void Awake() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);

        LoadSFXClips();
        LoadMusicClips();
    }

    private void LoadSFXClips() {
        sfxClips["Jump"] = Resources.Load<AudioClip>("SFX/Jump");
        sfxClips["Hit"] = Resources.Load<AudioClip>("SFX/Hit");
        sfxClips["Jingle"] = Resources.Load<AudioClip>("SFX/Jingle_Achievement");
        sfxClips["Shoot"] = Resources.Load<AudioClip>("SFX/Shoot");
        sfxClips["CollectCoin"] = Resources.Load<AudioClip>("SFX/Collect_Coin");
    }

    private void LoadMusicClips() {
        musicClips["MainTheme"] = Resources.Load<AudioClip>("Music/Main_Theme");
        musicClips["LoseALife"] = Resources.Load<AudioClip>("Music/Lost_A_Life");
        musicClips["LevelComplete"] = Resources.Load<AudioClip>("Music/Level_Complete");
        musicClips["InvincibilityTheme"] = Resources.Load<AudioClip>("Music/Invincibility_Theme");
    }

    public void PlaySFX(string clipName) {
        if (sfxClips.ContainsKey(clipName)) {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontró en el diccionario de sfxClips.");
    }

    public void PlayMusic(string clipName) {
        if (musicClips.ContainsKey(clipName)) {
            musicSource.clip = musicClips[clipName];
            musicSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontró en el diccionario de musicClips.");

        musicSource.loop = (clipName == "MainTheme") ? true : false;
    }

}