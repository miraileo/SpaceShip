using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{

    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip shootFastClip;
    [SerializeField] private AudioClip PickUpEffect;
    [SerializeField] private AudioClip DestroyEffect;

    [SerializeField] private AudioSource sourceEffects;
    [SerializeField] private AudioSource sourceMusic;

    [SerializeField] private GameObject settings;

    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderEffects;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<AudioScript>().Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
            DontDestroyOnLoad(gameObject);
            sourceEffects = GetComponent<AudioSource>();
    }

    public void PlayShoot()
    {
        sourceEffects.PlayOneShot(shootClip);
        sourceEffects.volume = 0.1f;
    }
    private void Update()
    {
        volumeUpdateEffects();
        volumeUpdateMusic();
    }
    public void PlayFastShoot()
    {
        sourceEffects.PlayOneShot(shootFastClip);
    }

    public void PickUp()
    {
        sourceEffects.PlayOneShot(PickUpEffect);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void Destroy()
    {
        sourceEffects.PlayOneShot(DestroyEffect);
    }

        public void volumeUpdateEffects()
    {
        sourceEffects.volume = sliderEffects.value;
    }

    public void volumeUpdateMusic()
    {
        sourceMusic.volume = sliderMusic.value;
    }
}
