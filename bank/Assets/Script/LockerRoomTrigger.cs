//using UnityEngine;

//public class LockerRoomTrigger : MonoBehaviour
//{
//    public AlertSystem alertSystem;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            alertSystem.StartAlert();
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            alertSystem.StopAlert();
//        }
//    }
//}


using UnityEngine;

public class LockerRoomTrigger : MonoBehaviour
{
    public AlertSystem alertSystem;
    public Light roomLight; // Reference to the light in the locker room

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            alertSystem.StartAlert();

            if (roomLight != null)
            {
                roomLight.enabled = false; // Disable the light
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            alertSystem.StopAlert();

            if (roomLight != null)
            {
                roomLight.enabled = true; // Re-enable the light when player leaves
            }
        }
    }
}
