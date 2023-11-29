using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class CheckPermissions : MonoBehaviour
{
    string[] permissions = {Permission.FineLocation, Permission.Camera};
    private void Start()
    {
        AskPermissions();
    }
    void AskPermissions()
    {
        if(Permission.HasUserAuthorizedPermission(Permission.Camera) == false 
            && Permission.HasUserAuthorizedPermission(Permission.FineLocation) == false)
        {
            Permission.RequestUserPermissions(permissions);
        }
    }
}
