
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Image = UnityEngine.UI.Image;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class BblueflagTrackable : MonoBehaviour, ITrackableEventHandler
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
    public static int btrackID;
    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        btrackID = 0;
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
            btrackID = 1;
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            btrackID = 0;
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            btrackID = 0;
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

        if (mTrackableBehaviour.TrackableName.Equals("B"))
        {
            btrackID = 1;
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
        btrackID = 0;
        // right.GetComponent<Text>().enabled = false;
    }

    #endregion // PRIVATE_METHODS
    void Update()
    {
        /*if (BblueflagTrackable.btrackID == 1 && ShuikuTrackable.shuikutrackID == 1)
        {
            //shuikutishi.SetActive(false);
            shuikutishi.GetComponent<Image>().enabled = true;
           
        }
        else if (BblueflagTrackable.btrackID == 1 && VillageTrackable.villagetrackID == 1)
        {
            //  shuikutishi.SetActive(true);
            shuikutishi.GetComponent<Image>().enabled =true;
          
        }
        else if (BblueflagTrackable.btrackID == 1 && XumuyeTrackable.xumuyetrackID == 1)
        {
            xumuyetishi.GetComponent<Image>().enabled = true;
           
        }
        else if (BblueflagTrackable.btrackID == 1 && NongyeTrackable.nongyetrackID == 1)
        {
            nongyetishi.GetComponent<Image>().enabled = false  ;
            
            nongye.SetActive(true);
            
        }
        else if (BblueflagTrackable.btrackID == 1 && HuagongchangTrackable.huagongchangtrackID == 1)
        {
            huagongchangtishi.GetComponent<Image>().enabled = true;
           
        }
        else
        {
           
        }*/
    

    }
}