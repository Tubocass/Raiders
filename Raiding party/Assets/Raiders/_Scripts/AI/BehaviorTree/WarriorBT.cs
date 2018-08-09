using UnityEngine;
using System.Collections;
using BTAI;

public class WarriorBT: MonoBehaviour 
{
    /*Follow Leader
		 * 		stick close to leader (don't chase x distance away)
		 * 		Kill anything immediately around
		 * 		Assist in anything the leader does
		 * Berserk
		 * 		Kill anything immediately around
		 * 		Look for and chase down enemies
		 * 
         * 
         * public void DecisionTree()
	        {
		        if(allowedToFight)
		        {
			        targetEnemy = NearestEnemy();
			        if(targetEnemy!=null)
			        {
				        chaseState = new State_Chase(this, targetEnemy);
				        BehaviourState = chaseState;
				        return;
			        }
		        }
		        if(Leader != null && Leader.isActive)
		        {
			        FollowLeader();//Can't find any targets, follow the Leader
		        }else 
		        {
			        BehaviourState = idleState;
			        pursuitRange = 50f;
		        }
	        }

         *  Behavior Tree
         *  Selector
         *      Berserk
         *          Condition(There are enemies nearby)
         *              Selector
         *                  Move to enemy
         *                  Attack enemy    
         *      Look for Treasure
         *          Condition(Treasure is nearby)
         *              Sequence
         *                  Move to pickup treasure
         *                  Carry treasure to ship
         *      Follow Leader
         *          Condition(I have a leader and he's alive)
         *              Action(Move to within short distance of leader)
         *      
         *      Example:
        ai = BT.Root();
        ai.OpenBranch(
            //First Round
            BT.SetActive(beamLaser, false),
            BT.Repeat(rounds.Length).OpenBranch(
                BT.Call(NextRound),
                //grenade enabled is true only on 2 and 3 round, so allow to just test if it's the 1st round or not here
                BT.If(GrenadeEnabled).OpenBranch(
                    BT.Trigger(animator, "Enabled")
                    ),
                BT.Wait(delay),
                BT.Call(ActivateShield),
                BT.Wait(delay),
                BT.While(ShieldIsUp).OpenBranch(
                    BT.RandomSequence(new int[] { 1, 6, 4, 4 }).OpenBranch(
                        BT.Root().OpenBranch(
                            BT.Trigger(animator, "Walk"),
                            BT.Wait(0.2f),
                            BT.WaitForAnimatorState(animator, "Idle")
                            ),
                        BT.Repeat(laserStrikeCount).OpenBranch(
                            BT.SetActive(beamLaser, true),
                            BT.Trigger(animator, "Beam"),
                            BT.Wait(beamDelay),
                            BT.Call(FireLaser),
                            BT.WaitForAnimatorState(animator, "Idle"),
                            BT.SetActive(beamLaser, false),
                            BT.Wait(delay)
                        ),
                        BT.If(EllenOnFloor).OpenBranch(
                            BT.Trigger(animator, "Lightning"),
                            BT.Wait(lightningDelay),
                            BT.Call(ActivateLightning),
                            BT.Wait(lightningTime),
                            BT.Call(DeactivateLighting),
                            BT.Wait(delay)
                        ),
                        BT.If(GrenadeEnabled).OpenBranch(
                            BT.Trigger(animator, "Grenade"),
                            BT.Wait(grenadeDelay),
                            BT.Call(ThrowGrenade),
                            BT.WaitForAnimatorState(animator, "Idle")
                        )
                    )
                ),
                BT.SetActive(beamLaser, false),
                BT.Trigger(animator, "Grenade", false),
                BT.Trigger(animator, "Beam", false),
                BT.Trigger(animator, "Lightning", false),
                BT.Trigger(animator, "Disabled"),
                BT.While(IsAlive).OpenBranch(BT.Wait(0))
            ),
            BT.Trigger(animator, "Death"),
            BT.SetActive(damageable.gameObject, false),
            BT.Wait(cleanupDelay),
            BT.Call(Cleanup),
            BT.Wait(deathDelay),
            BT.Call(Die),
            BT.Terminate()
        );
		 */
    GameObject Target;
    GameObject Leader;
    GameObject CarriedItem;
    Root ai;
    float attckCooldown;
    float leaderRange;
   [SerializeField] float health = 5;

    private void OnDisable()
    {

    }

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        ai.Tick();
    }

    void Init()
    {
        ai = BT.Root();
        ai.OpenBranch(
            BT.While(IsAlive).OpenBranch(
                 BT.Selector().OpenBranch(
                        //Am I within range of my leader
                        BT.Sequence().OpenBranch(
                            BT.Condition(LeaderIsAlive),
                            BT.Invert().Do(
                                BT.Condition(LeaderIsWithinRange)
                                ),
                            BT.Log("Leader is not nearby")//,
                            
                            )
                        //Are there enemies nearby
                        //Is there any Treasure nearby
                       )
                )  
        );
        
    }
    bool IsAlive()
    {
        return health>0;
    }
    bool LeaderIsAlive()
    {
        return true;
    }
    bool CanAttack()
    {
        return true;
    }
    bool LeaderIsWithinRange()
    {
        return false;
        //return TargetWithinRange(Leader, leaderRange);
    }
    bool TargetWithinRange(GameObject target, float range)
    {
        float a = (target.transform.position - transform.position).magnitude;
        return a<=range;
    }
    void TestMethod()
    {
        Debug.Log("Testing");
    }
    void SetTarget(GameObject newTarget)
    {}
    void SetLeader(GameObject newLeader)
    {}
    void SetTrigger(Animator anim, string trigger)
    {}
    void Attack(Vector3 dir)
    {}
    void Die()
    {}
    void PickUpItem(GameObject item)
    {}
    void PutDownItem(GameObject item)
    {}
    //void MoveTo(Vector3 dir)
    //{}
    //<T> NearestTarget(T)
    //{}
    float DistanceFromTarget(GameObject target)
    {
        return 0;
    }
        
           


}


