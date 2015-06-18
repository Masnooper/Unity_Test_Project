using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.Utility
{
	public class FPSController : MonoBehaviour
    {
        public Vector3andSpace moveUnitsPerSecond;
        public Vector3andSpace rotateDegreesPerSecond;
		public Transform PlayerGun;
		public int JoyMovementRange = 100;
		private Vector3 m_StartPos;

		void Start(){

			m_StartPos = transform.position;

		}
		public void OnPointerDown(PointerEventData data) { }
		public void OnDrag(PointerEventData data)
		{
			Vector3 newPos = Vector3.zero;
			
		
			int delta1 = (int)(data.position.x - m_StartPos.x);
			delta1 = Mathf.Clamp (delta1, - JoyMovementRange, JoyMovementRange);
			newPos.x = delta1;

				
			print (delta1);

			
			
			int delta2 = (int)(data.position.y - m_StartPos.y);
			delta2 = Mathf.Clamp (delta2, -JoyMovementRange, JoyMovementRange);
			newPos.y = delta2;
				
			//print (delta);
			
			transform.position = new Vector3 (m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);

		}
        // Update is called once per frame
         void Update()
        {
            
        
            PlayerGun.Rotate(rotateDegreesPerSecond.value*Time.deltaTime, moveUnitsPerSecond.space);
        }


        [Serializable]
        public class Vector3andSpace
        {
            public Vector3 value;
            public Space space = Space.Self;
        }
    }
}
