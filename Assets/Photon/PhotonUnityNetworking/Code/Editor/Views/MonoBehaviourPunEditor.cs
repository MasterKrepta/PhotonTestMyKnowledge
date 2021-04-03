// ----------------------------------------------------------------------------
// <copyright file="PhotonAnimatorViewEditor.cs" company="Exit Games GmbH">
//   PhotonNetwork Framework for Unity - Copyright (C) 2018 Exit Games GmbH
// </copyright>
// <summary>
//   This is a custom editor for the AnimatorView component.
// </summary>
// <author>developer@exitgames.com</author>
// ----------------------------------------------------------------------------

namespace Photon.Pun
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(MonoBehaviourPunCallacks))]
    public abstract class MonoBehaviourPunEditor : Editor
    {
        MonoBehaviourPunCallacks mbTarget;

        private void OnEnable()
        {
            mbTarget = target as MonoBehaviourPunCallacks;
        }

        public override void OnInspectorGUI()
        {
            mbTarget = target as MonoBehaviourPunCallacks;

            base.OnInspectorGUI();

            if (mbTarget.photonView == null)
            {
                EditorGUILayout.HelpBox("Unable to find a PhotonView on this GameObject or on any parent GameObject.", MessageType.Warning);
            }
        }


    }
}
