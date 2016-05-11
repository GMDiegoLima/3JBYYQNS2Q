using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    #region REMOVED
    /*
    public float acceleration = 5f;
    public float max_accel = 5f;
    public float mass = 1.0f;
    [Range(0,1)]
    public float angularSpeed = 2f;
    public float jumpHeight = 2.0f;
    public float gravityScale = 9f;

    public float footCheck = 0;
    */
    #endregion
    [SerializeField]
    public PlayerVariables variables;
    [SerializeField]
    public ControllerStates states;
    public enum direction
    {
        LEFT,
        RIGHT,
        NONE
    }
    Rigidbody2D m_rigid;
    public Rigidbody2D rigidbody
    {
        get
        {
            if (m_rigid == null)
                m_rigid = GetComponent<Rigidbody2D>();
            return m_rigid;
        }
    }

    const int ignorePlayer = -257;

    direction dir = direction.NONE;
    direction lastDir = direction.RIGHT;
    Vector2 axis = Vector2.zero;
    bool canJump = true;
    bool stopped, isGround, jump, ignoreGravity = false;
    // Use this for initialization
    void Start () {
        rigidbody.gravityScale = 0;
        rigidbody.freezeRotation = true;
	}
    void Update()
    {
        CheckFloor();
    }
	void FixedUpdate () {
        CheckInputs();
        ApplyMove();
        ApplyRotation();
    }
    void OnCollisionStay2D(Collision2D col)
    {
        //isGround = true;
    }
    /// <summary>
    /// Called INTERNAL Script
    /// </summary>
    public virtual void CheckInputs()
    {
        switch (dir)
        {
            case direction.LEFT:
                    axis.x = -1;
                    lastDir = dir;
                break;
            case direction.RIGHT:
                    axis.x = 1;
                    lastDir = dir;
                break;
            case direction.NONE:
                axis.x = 0;
                break;
        }
        //axis.y += (isJump) ? jumpHeight : 0;
    }
    /// <summary>
    /// Called INTERNAL Script
    /// </summary>
    public virtual void ApplyMove()
    {
        if (isGround)
        {
            axis.x *= variables.acceleration;
            axis.y -= (!isGround) ? variables.gravityScale : 0;
            axis.y = 0;
            //rigidbody.AddForce(axis, ForceMode2D.Impulse);

            Vector2 velocity = rigidbody.velocity;
            Vector2 velocityChange = axis - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -variables.max_accel, variables.max_accel);
            velocityChange.y = 0;
            rigidbody.AddForce(velocityChange);
        }
        if(!ignoreGravity)
        rigidbody.AddForce(new Vector2(0, -variables.gravityScale * variables.mass));
        isGround = false;
        jump = false;    
    }
    /// <summary>
    /// Called INTERNAL Script
    /// </summary>
    public virtual void ApplyRotation()
    {
        Quaternion rot = transform.rotation;
        switch (lastDir)
        {
            case direction.LEFT:
                rot = Quaternion.Euler(new Vector3(0, -180, 0));
                break;
            case direction.RIGHT:
                rot = Quaternion.Euler(Vector3.zero);
                break;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, variables.angularSpeed);
    }
    /// <summary>
    /// Called INTERNAL Script
    /// </summary>
    public virtual void CheckFloor()
    {
        Vector3 origin = transform.position;
        origin.y -= variables.footCheck;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.01f, ignorePlayer);
        if (hit)
        {
            isGround = true;
        }
    }
    /// <summary>
    /// Choose Direction Player
    /// </summary>
    /// <param name="direction">Set Direction Controller Move</param>
    public virtual void Move(direction direction)
    {
        dir = direction;
        //ApplyMove();
    }
    /// <summary>
    /// Apply Jump to the Controller
    /// </summary>
    public virtual void Jump()
    {
        if(isGround)
            if(canJump)
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, CalculateJumpVerticalSpeed());
    }
    /// <summary>
    /// Disable Jump Action
    /// Warning: Don't Stop Controller in mid air, use Stop(true) instead this method
    /// </summary>
    public virtual void StopJump()
    {
        canJump = false;
    }
    /// <summary>
    /// Stop Player
    /// </summary>
    /// <param name="ignoreGravity">Stop Player and Don't Simulate Gravity</param>
    public virtual void Stop(bool ignoreGravity=false)
    {
        dir = direction.NONE;
        stopped = true;
        this.ignoreGravity = ignoreGravity;
    }

    public void SetState(string state)
    {
        CState s = states.states.Find(x => x.name == state);
        if (s == null)
            return;

        Debug.Log(s.obj);
        variables.acceleration = s.obj.acceleration;
        variables.max_accel = s.obj.max_accel;
        variables.mass = s.obj.mass;
        variables.angularSpeed = s.obj.angularSpeed;
        variables.jumpHeight = s.obj.jumpHeight;
        variables.footCheck = s.obj.footCheck;
    }

    public virtual float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * variables.jumpHeight * variables.gravityScale);
    }
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 pos = transform.position;
        pos.y -= variables.footCheck;
        Gizmos.DrawWireSphere(pos, 0.1f);
    }
#endif
}
[System.Serializable]
public class PlayerVariables
{
    public float acceleration = 5f;
    public float max_accel = 5f;
    public float mass = 1.0f;
    /*
    [Range(0,1)]
    public float friction = 0.5f;
    */
    [Range(0, 1)]
    public float angularSpeed = 2f;
    public float jumpHeight = 2.0f;
    public float gravityScale = 9f;

    public float footCheck = 0;

    public override string ToString()
    {
        return string.Format("Acceleration:{0}, \n Max_Accel:{1}, \n Mass:{2} \n, Angular Speed:{3} \n, Jump Height:{4}, \n Gravity Scale:{5}, \n Foot Check:{6}",acceleration,max_accel,mass,angularSpeed,jumpHeight,gravityScale,footCheck);
    }
}
