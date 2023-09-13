using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField] private GameObject menuButton;

    public Button sourceButton;
    [SerializeField] private Button shopButton;

    private bool stopFindingShit;
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
        if(SceneManager.GetActiveScene().buildIndex == 1 && stopFindingShit == false)
        {
            shopButton = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Button>();
            settings.SetActive(false);
            stopFindingShit = true;
        }
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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            menuButton.SetActive(false);
        }
        else
        {
            menuButton.SetActive(true);
            shopButton.interactable = false;
        }
    }

    public void CloseSettings()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            shopButton.interactable = true;
        }
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

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        settings.SetActive(false);
    }
}
