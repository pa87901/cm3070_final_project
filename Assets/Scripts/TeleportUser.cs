using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Teleport the user to a teleporation anchor.

public class TeleportUser : MonoBehaviour
{
    [Tooltip("The anchor the user is teleported to.")]
    public TeleportationAnchor anchor = null;

    [Tooltip("The provider used to request the teleportation.")]
    public TeleportationProvider provider = null;

    public void Teleport()
    {
        if(anchor && provider)
        {
            TeleportRequest request = CreateRequest();
            provider.QueueTeleportRequest(request);
        }
    }

    private TeleportRequest CreateRequest()
    {
        Transform anchorTransform = anchor.teleportAnchorTransform;

        TeleportRequest request = new TeleportRequest()
        {
            requestTime = Time.time,
            matchOrientation = anchor.matchOrientation,

            destinationPosition = anchorTransform.position,
            destinationRotation = anchorTransform.rotation
        };

        return request;
    }
}
