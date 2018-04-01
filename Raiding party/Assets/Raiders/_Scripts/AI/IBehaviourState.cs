using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviourState
{
	void EnterState();
	void ExitState();
	//void Animate();
	void AssesSituation();
}
