using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class NightsController : MonoBehaviour
{
    public Pumpkin pumpkin;
    public Clown clown;
    public JesterInTheBox jester;
    public Canvas Win;
    public Button NextNight;
    public Buttary buttary;
    // Start is called before the first frame update
    void Start()
    {
        Win.gameObject.SetActive(false);
        NextNight.onClick.AddListener(PlayNextNight);
        PlayNextNight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayNextNight()
    {
        if (PlayerPrefs.GetInt("Nights") == 0)
        {
            PlayFirstNight();
            Win.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Nights") == 1)
        {
            PlaySecondNight();
            Win.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Nights") == 2)
        {
            PlayThirdNight();
            Win.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Nights") == 3)
        {
            PlayThirdNight();
            Win.gameObject.SetActive(false);
        }
    }

    async Task PlayFirstNight()
    {
        //jester.Play();
        pumpkin.Walk();
        await Task.Delay(60*1000);
        pumpkin.Sleep();
        //jester.Sleep();
        Win.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Nights", 1);
    }

    async Task PlaySecondNight()
    {
        buttary.Fill();
        pumpkin.Walk();
        clown.Walk();
        await Task.Delay(60*1000);
        pumpkin.Sleep();
        clown.Sleep();
        Win.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Nights", 2);
    }

    async Task PlayThirdNight()
    {
        buttary.Fill();
        clown.Walk();
        jester.Play();
        await Task.Delay(60*1000);
        clown.Sleep();
        jester.Sleep();
        Win.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Nights", 3);
    }
}
