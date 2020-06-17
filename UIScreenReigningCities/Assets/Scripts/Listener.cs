using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    /* The only purpose of this class is to listen 
     * for callbacks from platform specific native code
     */

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void playerEmail(string email)
    {
        RCSession session = FindObjectOfType<RCSession>();
        session.setEmail(email);
    }

}
