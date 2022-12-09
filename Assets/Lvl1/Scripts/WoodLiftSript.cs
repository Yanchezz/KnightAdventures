using UnityEngine;
public class WoodLiftSript : MonoBehaviour
{
    private SliderJoint2D joint;
    public float point1;
    public float point2;
    private JointMotor2D motor;
    void Start()
    {
        joint = GetComponent<SliderJoint2D>();
        motor = joint.motor;
    }
    void Update()
    {
        LiftMove(); 
    }
    private void LiftMove()
    {
        if (transform.position.y >= point1)
        {
            motor.motorSpeed = 1;
            joint.motor = motor;
        }  
        else
        {
            if (transform.position.y <= point2)
            {
                motor.motorSpeed = -1;
                joint.motor = motor;
            }
        }
    }
}