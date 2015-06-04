using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class touchINput : MonoBehaviour {
    public class State
    {
        public Vector2 position;
        public Vector2 deltaPosition;
        public TouchPhase phase;
        public int fingerID;
        public void copyFrom(State source)
        {
            position = source.position;
            deltaPosition = source.deltaPosition;
            phase = source.phase;
            fingerID = source.fingerID;
        }
    }

    public static touchINput instance { get; private set; }

    public delegate void DelTouchEvent(State state, ref bool processed);
    public event DelTouchEvent EvtOnTouchDown;
    public event DelTouchEvent EvtOnTouchUp;
    public event DelTouchEvent EvtOnTouchDrag;

#if UNITY_ANDROID
    State mTmpState = new State();
#else
    State mMouseState = new State();
#endif

    void InvokeEvent(DelTouchEvent evt, State state)
    {
        if (evt == null) return;
        object[] param = { state, false };
        System.Delegate[] delegates = evt.GetInvocationList();
        foreach (System.Delegate del in delegates)
        {
            del.DynamicInvoke(param);
            if ((bool)param[1]) break;
        }
    }

    void OnEnable()
    {
        if (instance != null)
        {
            if (GetComponents<Component>().Length == 2) Destroy(gameObject);
            else Destroy(this);
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IPHONE
		// handle TOUCH!
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				mTmpState.position = touch.position;
				mTmpState.deltaPosition = touch.deltaPosition;
				mTmpState.fingerID = touch.fingerId;
				mTmpState.phase = TouchPhase.Began;
				
				InvokeEvent(EvtOnTouchDown, mTmpState);
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				mTmpState.position = touch.position;
				mTmpState.deltaPosition = touch.deltaPosition;
				mTmpState.fingerID = touch.fingerId;
				mTmpState.phase = TouchPhase.Moved;
				
				InvokeEvent(EvtOnTouchDrag, mTmpState);
			}
			else if (touch.phase == TouchPhase.Ended ||touch.phase == TouchPhase.Canceled)
			{
				mTmpState.position = touch.position;
				mTmpState.deltaPosition = touch.deltaPosition;
				mTmpState.fingerID = touch.fingerId;
				mTmpState.phase = touch.phase;
				
				InvokeEvent(EvtOnTouchUp, mTmpState);
			}
        }
#elif UNITY_EDITOR
		// handle MOUSE!
		Vector2 mousePos = Input.mousePosition;
		if (Input.GetMouseButtonDown(0))
		{
			mMouseState.position = mousePos;
			mMouseState.deltaPosition = Vector2.zero;
			mMouseState.fingerID = 0;
			mMouseState.phase = TouchPhase.Began;
			
			InvokeEvent(EvtOnTouchDown, mMouseState);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			mMouseState.position = mousePos;
			mMouseState.deltaPosition = Vector2.zero;
			mMouseState.fingerID = 0;
			mMouseState.phase = TouchPhase.Ended;
			
			InvokeEvent(EvtOnTouchUp, mMouseState);
		}
		else if (
			Input.GetMouseButton(0) &&
			mMouseState.position != mousePos)
		{
			mMouseState.deltaPosition = mousePos - mMouseState.position;
			mMouseState.position = mousePos;
			mMouseState.fingerID = 0;
			mMouseState.phase = TouchPhase.Moved;
			
			InvokeEvent(EvtOnTouchDrag, mMouseState);
		}
#endif
    }
}
