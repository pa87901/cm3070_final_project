using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// This scripts ensures that the XR Ray Interactor is toggled off when the XR Direct Interactor is activated.

// This script is a component of the XR Ray Interactor.
[RequireComponent(typeof(XRRayInteractor))]

public class ToggleRay : MonoBehaviour {
    [Tooltip("Switch even if an object is selected.")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool isSwitched = false;

    private void Awake() {
        rayInteractor = GetComponent<XRRayInteractor>();
        SwitchInteractors(false);
    }

    public void ActivateRay() {
        if (!TouchingObject() || forceToggle)
            SwitchInteractors(true);
    }

    public void DeactivateRay() {
        if (isSwitched)
            SwitchInteractors(false);
    }

    private bool TouchingObject() {
        List<IXRInteractable> targets = new List<IXRInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    private void SwitchInteractors(bool value) {
        isSwitched = value;
        rayInteractor.enabled = value;
        directInteractor.enabled = !value;
    }
}