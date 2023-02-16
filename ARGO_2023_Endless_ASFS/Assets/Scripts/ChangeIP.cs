using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace Mirror.Examples.Basic
{
    public class ChangeIP : MonoBehaviour
    {
        public void changeIP()
        {
            InputField _inputField = this.GetComponent<InputField>();
            FindObjectOfType<NewNetworkRoomManager>().networkAddress = _inputField.text;
        }
    }


}
