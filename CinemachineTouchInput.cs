using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class CinemachineTouchInput : MonoBehaviour
{
     public float TouchSensitivity_x = 10f;
     public float TouchSensitivity_y = 10f;
     float x_val;
     float y_val;
 
     // Use this for initialization
     void Start () {
         CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
     }
     
     float HandleAxisInputDelegate(string axisName)
     {
         switch(axisName)
         {
 
             case "Mouse X":
                    
                 if (Input.touchCount>0)
                 {
                     x_val=0;
                     for(int i =0; i< Input.touchCount; i++){
                        if((EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId))){
                            if (x_val==0){
                                x_val = 0;
                            }
                            
                            
                        }
                        else{
                            x_val= Input.touches[i].deltaPosition.x / TouchSensitivity_x;
                            
                        }
                        
                     }
                     return x_val;
                     
                 }else{
                     return Input.GetAxis(axisName);
                     
                     
                 }
 
             case "Mouse Y":
                 if (Input.touchCount > 0 )
                 {
                     y_val=0;
                     for(int i =0; i< Input.touchCount; i++){
                        if((EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId))){
                            if (y_val==0){
                                y_val = 0;
                            }
                            
                        }
                        else{
                            y_val= Input.touches[i].deltaPosition.y / TouchSensitivity_y;
                            
                        }
                        
                     }
                     return y_val;
                     
                 }
                 else
                 {
                     return Input.GetAxis(axisName);
                     
                     
                 }
 
             default:
                 Debug.LogError("Input <"+axisName+"> not recognyzed.",this);
                 break;
         }
 
         return 0f;
     }
}
