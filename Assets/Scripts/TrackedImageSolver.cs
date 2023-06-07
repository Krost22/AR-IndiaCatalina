using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
public class TrackedImageSolver : MonoBehaviour
{
    private ARTrackedImageManager _arManager;
    // Start is called before the first frame update
    private void Awake()
    {
        _arManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _arManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        _arManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args) 
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
    
    
    }
}
