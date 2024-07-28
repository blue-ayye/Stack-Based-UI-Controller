using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluePixel.UISystem
{
    public class UIPage : MonoBehaviour
    {
        [SerializeField] private bool _disableWhenNextPageOpens;

        public bool DisableWhenNextPageOpens => _disableWhenNextPageOpens;

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
