using UnityEngine;
using System.Collections;

public interface ITap
{ 
	// タッチしたときに呼ばれる。
	void TapDown2D (ref RaycastHit2D hit);
	// タッチを離したときに呼ばれる。
	void TapUp2D(ref RaycastHit2D hit);
}

