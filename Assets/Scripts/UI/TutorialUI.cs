using System.Collections.Generic;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;

namespace UI
{
    public class TutorialUI : MonoBehaviour
    {
        [SerializeField] private List<UITranslateAnim> m_MainWays;
        [SerializeField] private List<UITranslateAnim> m_ComboWays;

        private int m_Index;
        public void OnBeatChangeEvent()
        {
            if (m_Index == 0)
            {
                foreach (var ma in m_MainWays)
                {
                    ma.FadeIn();
                }
            }
            else
            {
                foreach (var ma in m_ComboWays)
                {
                    ma.FadeIn();
                }
            }

            Conditional.Wait(2f).Do(TurnOff);
        }

        private void TurnOff()
        {
            if (m_Index == 0)
            {
                foreach (var ma in m_MainWays)
                {
                    ma.FadeOut();
                }
            }
            else
            {
                foreach (var ma in m_ComboWays)
                {
                    ma.FadeOut();
                }
            }
        }
    }
}
