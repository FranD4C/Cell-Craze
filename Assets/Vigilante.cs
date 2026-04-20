using UnityEngine;

public class Vigilante : MonoBehaviour
{
    Detect los;
    [SerializeField] GameObject player;
    [SerializeField] GameObject indicator;

    [SerializeField] private int distance;
    [SerializeField] private int angle;
    [SerializeField] private LayerMask obs;

    private void Awake()
    {
        los = new Detect();
    }

   //// void Update()
   // {
   //     if (los.CheckRange(transform, player.transform, distance) &&
   //         los.CheckAngle(transform, player.transform, angle) &&
   //         los.CheckObstacles(transform, player.transform, obs))
   //     {
   //         indicator.SetActive(true);
   //     }
   //     else
   //     {
   //         indicator.SetActive(false);
   //     }
   // }
   //     //

}
