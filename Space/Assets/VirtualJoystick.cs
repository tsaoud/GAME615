//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{

//    //sprite getting dragged
//    public RectTransform thumb;

//    //locations of thumb and joystick w/o dragging occuring
//    private Vector2 originalPosition;
//    private Vector2 originalThumbPosition;

//    //distance the thumb is dragged from original pos
//    public Vector2 delta;

//    // Start is called before the first frame update
//    void Start()
//    {
//        //record original pos when joystick starts up
//        originalPosition = this.GetComponent<RectTransform>().localPosition;
//        originalThumbPosition = thumb.localPosition;

//        //disable thumb visability
//        thumb.gameObject.SetActive(false);

//        //reset delta to zero
//        delta = Vector2.zero;
//    }

//    //called when dragging starts
//    public void onBeginDrag (PointerEventData eventData)
//    {
//        //make thumb visible
//        thumb.gameObject.SetActive(true);

//        //figure out where drag started
//        Vector3 worldPoint = new Vector3();
//        RectTransformUtility.ScreenPointToLocalPointInRectangle(
//            this.transform as RectTransform,
//            eventData.position,
//            eventData.enterEventCamera,
//            out worldPoint);

//        //place joystick at that point
//        this.GetComponent<RectTransform>().position = worldPoint;

//        //make sure thumb in original location relative to joystick
//        thumb.localPosition = originalThumbPosition;
//    }

//    //called when drag moves
//    public void OnDrag (PointerEventData eventData)
//    {
//        //figure out where drag is now
//        Vector3 worldPoint = new Vector3;
//        RectTransformUtility.ScreenPointToLocalPointInRectangle(
//            this.transform as RectTransform,
//            eventData.position,
//            eventData.enterEventCamera,
//            out worldPoint);

//        //place thumb at that point
//        thumb.position = worldPoint;

//        //calculate distance from original position
//        var size = GetComponent<RectTransform>().rect.size;

//        delta = thumb.localPosition;

//        delta.x /= size.x / 2.0f;
//        delta.y /= size.y / 2.0f;

//        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
//        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
//    }

//    //called when dragging ends
//    public void OnEndDrag (PositionEventData eventData)
//    {
//        //reset joystick position
//        this.GetComponent<RectTransform>().localPosition = originalPosition;

//        //reset distance to zero
//        delta = Vector2.zero;

//        //hide the thumb
//        thumb.gameObject.SetActive(false);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Get access to the Event interfaces
using UnityEngine.EventSystems;

// Get access to UI elements
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour,
  IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // The sprite that gets dragged around
    public RectTransform thumb;

    // The locations of the thumb and joystick when no dragging
    // is happening
    private Vector2 originalPosition;
    private Vector2 originalThumbPosition;

    // The distance that the thumb has been dragged away from
    // its original position
    public Vector2 delta;

    void Start()
    {
        // When the joystick starts up, record the original
        // positions
        originalPosition
          = this.GetComponent<RectTransform>().localPosition;
        originalThumbPosition = thumb.localPosition;

        // Disable the thumb so that it's not visible
        thumb.gameObject.SetActive(false);

        // Reset the delta to zero
        delta = Vector2.zero;
    }

    // Called when dragging starts
    public void OnBeginDrag(PointerEventData eventData)
    {

        // Make the thumb visible
        thumb.gameObject.SetActive(true);

        // Figure out where in world-space the drag started
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
          this.transform as RectTransform,
          eventData.position,
          eventData.enterEventCamera,
          out worldPoint);

        // Place the joystick at that point
        this.GetComponent<RectTransform>().position
          = worldPoint;

        // Ensure that the thumb is in its original location,
        // relative to the joystick
        thumb.localPosition = originalThumbPosition;
    }

    // Called when the drag moves
    public void OnDrag(PointerEventData eventData)
    {

        // Work out where the drag is in world space now
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
          this.transform as RectTransform,
          eventData.position,
          eventData.enterEventCamera,
          out worldPoint);

        // Place the thumb at that point
        thumb.position = worldPoint;

        // Calculate distance from original position
        var size = GetComponent<RectTransform>().rect.size;

        delta = thumb.localPosition;

        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;

        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);

    }

    // Called when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset the position of the joystick
        this.GetComponent<RectTransform>().localPosition
          = originalPosition;

        // Reset the distance to zero
        delta = Vector2.zero;

        // Hide the thumb
        thumb.gameObject.SetActive(false);
    }
}
