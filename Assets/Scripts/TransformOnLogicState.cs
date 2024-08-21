using System.Collections;
using UnityEngine;

namespace Unity.Template.VR
{
    public class TransformOnLogicState : LogicBehaviour
    {
        public Vector3 translateDelta;
        public Vector3 rotationDelta;
        public Vector3 scaleDelta;

        public float time = 0.5f;

        private Vector3 _initialPosition;
        private Vector3 _initialEulerAngles;
        private Vector3 _initialScale;

        protected override void CustomStart()
        {
            Transform tf = transform;
            _initialPosition = tf.position;
            _initialEulerAngles = tf.localEulerAngles;
            _initialScale = tf.localScale;
            iTween.Init(gameObject);
        }
        
        protected override void OnLogicStateChange()
        {
            Vector3 targetPos;
            Vector3 targetRot;
            Vector3 targetScale;
            if (state)
            {
                targetPos = _initialPosition + transform.InverseTransformDirection(translateDelta);
                targetRot = _initialEulerAngles + rotationDelta;
                targetScale = _initialScale + scaleDelta;
            }
            else
            {
                targetPos = _initialPosition;
                targetRot = _initialEulerAngles;
                targetScale = _initialScale;
            }
            iTween.Stop(gameObject);
            if(translateDelta != Vector3.zero)
                iTween.MoveTo(gameObject, targetPos, time);
            if(rotationDelta != Vector3.zero)
                iTween.RotateTo(gameObject, iTween.Hash("time", time, "rotation", targetRot, "isLocal", true));
            if(scaleDelta != Vector3.zero)
                iTween.ScaleTo(gameObject, iTween.Hash("time", time, "scale", targetScale, "isLocal", true));
        }
    }
}