using OneSignalSDK;
using UnityEngine;

public class PushLoader : MonoBehaviour
{

    private const string appId = "635c5f12-bb1c-4e8a-92a5-65636c604328";

    private void Awake()
    {
        OneSignal.Initialize(appId);
    }
}
