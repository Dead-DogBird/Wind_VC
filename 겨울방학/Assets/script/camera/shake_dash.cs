using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake_dash : MonoBehaviour
{
    Vector3 realOriginalPos = Vector3.zero;
    Quaternion realOriginalRot = Quaternion.identity;
    public bool Shaking;
    float ShakeDecay;
    float ShakeIntensity;
    Vector3 OriginalPos;
    Quaternion OriginalRot;

	GameObject player;
    void Start()
    {
        realOriginalPos = transform.position;
        realOriginalRot = transform.rotation;
        Shaking = false;
		player=GameObject.Find("player");
    }

    public void DoShake()
    {
        OriginalPos = realOriginalPos;

        OriginalRot = realOriginalRot;
        ShakeIntensity = 0.04f;

        ShakeDecay = 0.02f;

        Shaking = true;

    }
    void Update()
    {
        if (ShakeIntensity > 0)
        {
            transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
            transform.rotation = new Quaternion(
                 OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .1f,
                 OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .1f,
                 OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .1f,
                 OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .1f);
            ShakeIntensity -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;
        }
		transform.position=player.transform.position-new Vector3(0,0,10);
    }
}