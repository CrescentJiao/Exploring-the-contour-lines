
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Image = UnityEngine.UI.Image;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class EwhiteflagTrackable : MonoBehaviour, ITrackableEventHandler
{
    //public GameObject Aredflag;
    public GameObject shuiku1;
    public GameObject juminqu1;
    public GameObject nongye;
    public GameObject xumuye;
    public GameObject huagongchang;

    public GameObject nongyetishi;
    public GameObject juminqutishi;
    public GameObject xumuyetishi;
    public GameObject huagongchangtishi;
    public GameObject shuikutishi;
    //public AudioSource wrongsound;

    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PRIVATE_MEMBER_VARIABLES
    public static int etrackID;
    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
       etrackID = 0;
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            etrackID = 1;
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            etrackID = 0;
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            etrackID = 0;
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;
        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;
        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;


        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

        if (mTrackableBehaviour.TrackableName.Equals("E"))
        {
            etrackID = 1;
        }

    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        //var lightComponents = GetComponentInChildren<RenderingPath>(true);
        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        etrackID = 0;
        // right.GetComponent<Text>().enabled = false;
    }

    #endregion // PRIVATE_METHODS
    void Update()
    {
       /* if (EwhiteflagTrackable.etrackID == 1 && ShuikuTrackable.shuikutrackID == 1)
        {
            //shuikutishi.SetActive(false);
          //  juminqutishi.GetComponent<Image>().enabled = true;
            shuikutishi.GetComponent<Image>().enabled = true;
            shuiku1.SetActive(false);
            juminqu1.SetActive(false);
            nongye.SetActive(false);
            xumuye.SetActive(false);
            huagongchang.SetActive(false);

        }
        else if (EwhiteflagTrackable.etrackID == 1 && VillageTrackable.villagetrackID == 1)
        {
            //  shuikutishi.SetActive(true);
            juminqutishi.GetComponent<Image>().enabled = true;
            shuiku1.SetActive(false);
            juminqu1.SetActive(false);
            nongye.SetActive(false);
            xumuye.SetActive(false);
            huagongchang.SetActive(false);
        }
        else if (EwhiteflagTrackable.etrackID == 1 && NongyeTrackable.nongyetrackID == 1)
        {
            nongyetishi.GetComponent<Image>().enabled = true;
            shuiku1.SetActive(false);
            juminqu1.SetActive(false);
            nongye.SetActive(false);
            xumuye.SetActive(false);
            huagongchang.SetActive(false);
            //  wrongsound.Play(); wrongsound.loop = false;

        }
        else if (EwhiteflagTrackable.etrackID == 1 && XumuyeTrackable.xumuyetrackID == 1)
        {
            //  shuikutishi.SetActive(true);
            xumuyetishi.GetComponent<Image>().enabled = false;
            shuiku1.SetActive(false);
            juminqu1.SetActive(false);
            nongye.SetActive(false);
            xumuye.SetActive(true);
            huagongchang.SetActive(false);

        }
        else if (EwhiteflagTrackable.etrackID == 1 && HuagongchangTrackable.huagongchangtrackID == 1)
        {
            //  shuikutishi.SetActive(true);
            huagongchangtishi.GetComponent<Image>().enabled = true;
            shuiku1.SetActive(false);
            juminqu1.SetActive(false);
            nongye.SetActive(false);
            xumuye.SetActive(false);
            huagongchang.SetActive(false);
        }
        else
        {
            //shuikutishi.GetComponent<Image>().enabled = false;
           // juminqutishi.GetComponent<Image>().enabled = false;
           // nongyetishi.GetComponent<Image>().enabled = false;
           // xumuyetishi.GetComponent<Image>().enabled = false;
            //huagongchangtishi.GetComponent<Image>().enabled = false;
        }
        //shuikutishi.SetActive(false);*/

    }
}