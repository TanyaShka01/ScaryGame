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
    int PreviousNight = 0;
    // Start is called before the first frame update
    void Start()
    {
        Win.gameObject.SetActive(false);
        PlayFirstNight();
        NextNight.onClick.AddListener(PlayNextNight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayNextNight()
    {
        if (PreviousNight == 1)
        {
            PlaySecondNight();
            Win.gameObject.SetActive(false);
        }
        if (PreviousNight == 2)
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
        PreviousNight += 1;
    }

    async Task PlaySecondNight()
    {
        pumpkin.Walk();
        clown.Walk();
        await Task.Delay(60*1000);
        pumpkin.Sleep();
        clown.Sleep();
        Win.gameObject.SetActive(true);
        PreviousNight += 1;
    }

    async Task PlayThirdNight()
    {
        clown.Walk();
        await Task.Delay(60*1000);
        clown.Sleep();
        Win.gameObject.SetActive(true);
        PreviousNight += 1;
    }
}
