using UnityEngine;
using System.Collections;

public interface ITap
{ 
	// タッチしたときに呼ばれる。
	void TapDown (ref RaycastHit hit);
	// タッチを離したときに呼ばれる。
	void TapUp(ref RaycastHit hit);
}

