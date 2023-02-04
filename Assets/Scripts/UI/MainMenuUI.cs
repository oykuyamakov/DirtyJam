using System;
using Events;
using SceneManagement;
using UnityEngine;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        private bool m_ButtonPressed;

        private void Awake()
        {
            m_ButtonPressed = false;
        }

        public void LoadGame()
        {
            if(m_ButtonPressed)
                return;
            
            m_ButtonPressed = true;

            using var evt = SceneChangeRequestEvent.Get(SceneId.Game);
            evt.SendGlobal();
        }
    }
}
