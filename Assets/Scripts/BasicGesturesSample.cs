using UnityEngine;
using System.Collections;

public class BasicGesturesSample :MonoBehaviour
{
    public GameObject longPressObject;
    public GameObject tapObject;
    public GameObject doubleTapObject;
    public GameObject swipeObject;
    public GameObject dragObject;


    void OnSwipe( SwipeGesture gesture )
    {
        // make sure we started the swipe gesture on our swipe object
        //   we use the object the swipe started on, instead of the current one
        GameObject selection = gesture.StartSelection;

        if( selection == swipeObject )
        {
            if(gesture.Direction == FingerGestures.SwipeDirection.Up && GlobalData.Instance.worldType == false){
                selection.GetComponent<Grow>().growUp();
            }
            string msg = "Swiped " + gesture.Direction + " with finger " + gesture.Fingers[0] +
                " (velocity:" + gesture.Velocity + ", distance: " + gesture.Move.magnitude + " )";

            Debug.Log( msg );

            // SwipeParticlesEmitter emitter = selection.GetComponentInChildren<SwipeParticlesEmitter>();
            // if( emitter )
            //     emitter.Emit( gesture.Direction, gesture.Velocity );
        }
    }

    void OnTap( TapGesture gesture )
    {
        if( gesture.Selection == tapObject )
        {

            string msg = "Tapped with finger " + gesture.Fingers[0];
            Debug.Log( msg );
        }
    }
    
    void OnDoubleTap( TapGesture gesture )
    {
        if( gesture.Selection == doubleTapObject )
        {

            string msg = "Double-Tapped with finger " + gesture.Fingers[0];
            Debug.Log("doubleTap");
        }
    }

    void OnLongPress( LongPressGesture gesture )
    {
        if( gesture.Selection == longPressObject )
        {
            string msg = "Performed a long-press with finger " + gesture.Fingers[0];
            Debug.Log(msg);
            gesture.Selection.GetComponent<WorldTypeControl>().ChangeWorldType();
        }
    }

    

    int dragFingerIndex = -1;

    void OnDrag( DragGesture gesture )
    {
        // first finger
        FingerGestures.Finger finger = gesture.Fingers[0];

        if( gesture.Phase == ContinuousGesturePhase.Started )
        {
            // dismiss this event if we're not interacting with our drag object
            if( gesture.Selection != dragObject )
                return;

            Debug.Log( "Started dragging with finger " + finger);

            // remember which finger is dragging dragObject
            dragFingerIndex = finger.Index;

        }
        else if( finger.Index == dragFingerIndex )  // gesture in progress, make sure that this event comes from the finger that is dragging our dragObject
        {
            if( gesture.Phase == ContinuousGesturePhase.Updated )
            {
                // update the position by converting the current screen position of the finger to a world position on the Z = 0 plane
                dragObject.transform.position = GetWorldPos( gesture.Position );
            }
            else
            {
                Debug.Log( "Stopped dragging with finger " + finger);

                // reset our drag finger index
                dragFingerIndex = -1;

            }
        }
    }

    // Convert from screen-space coordinates to world-space coordinates on the Z = 0 plane
    public static Vector3 GetWorldPos( Vector2 screenPos )
    {
        Ray ray = Camera.main.ScreenPointToRay( screenPos );

        // we solve for intersection with z = 0 plane
        float t = -ray.origin.z / ray.direction.z;

        return ray.GetPoint( t );
    }
}

    // #endregion

    // #region Properties exposed to the editor



//     #endregion


//     #region Misc

//     protected override string GetHelpText()
//     {
//         return @"This sample demonstrates some of the supported single-finger gestures:

// - Drag: press the red sphere and move your finger to drag it around  

// - LongPress: keep your finger pressed on the cyan sphere for a few seconds

// - Tap: press & release the purple sphere 

// - Double Tap: quickly press & release the green sphere twice in a row

// - Swipe: press the yellow sphere and move your finger in one of the four cardinal directions, then release. The speed of the motion is taken into account.";
//     }

    // #endregion 

    // #region Utils

    // void SpawnParticles( GameObject obj )
    // {
    //     ParticleEmitter emitter = obj.GetComponentInChildren<ParticleEmitter>();
    //     if( emitter )
    //         emitter.Emit();
    // }

    // #endregion