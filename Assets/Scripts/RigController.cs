//using System;
//using UnityEngine;

//public class RigController : MonoBehaviour
//{
//    // Start is called before the first frame update
   
//       public GameObject humanoid;
//    public Vector3 bodyRotation = new Vector3(0, 0, 0);
//    public Array arr2 = new int[3];


//    public int mov = 147 ;
//    public int mov1 = -20;
//    public int mov2 = -159;

//    //Variables del hombor derecho
//    public int xshoulderRight = 0;
//    public int yshoulderRight = 0;
//    public int zshoulderRight = 0;

//    //Variables del hombro izquierdo
//    public int xshoulderLeft = 0;
//    public int yshoulderLeft = 0;
//    public int zshoulderLeft = 0;

//    //Variables del codo derecho
//    public float xelbowRight = 103;
//    public float yelbowRight = -331;
//    public float zelbowRight = -336;

//    //Variables del codo izquierdo
//    public int xelbowLeft = 0;
//    public int yelbowLeft = 0;
//    public int zelbowLeft = 0;

//    //Variables del muñeca izquierda
//    public int xWristLeft = 0;
//    public int yWristLeft = 0;
//    public int zWristLeft = 0;

//    //Variables del muñeca derecho
//    public int xWristRight = 0;
//    public int yWristRight = 0;
//    public int zWristRight = 0;



//    //HUESOS DEL HUMANOIDE

//    //hombros
//    RigBone leftShoulder;
//    RigBone rightShoulder;

//    //Anterbrazos
//    RigBone rightUpperArm;
//    RigBone leftUpperArm; 
    
//    //Codos
//    RigBone rightLowerArm;
//    RigBone leftLowerArm;

//    //muñecas
//    RigBone rightHand;
//    RigBone leftHand;

//    //dedos de la mano derecha 
//    RigBone falangepulgar1d;
//    RigBone falangepulgar2d;
//    RigBone falangepulgar3d;

//    RigBone falangeindice1d;
//    RigBone falangeindice2d;
//    RigBone falangeindice3d;

//    RigBone falangemedio1d;
//    RigBone falangemedio2d;
//    RigBone falangemedio3d;

//    RigBone falangeanular1d;
//    RigBone falangeanular2d;
//    RigBone falangeanular3d;

//    RigBone falangemeñique1d;
//    RigBone falangemeñique2d;
//    RigBone falangemeñique3d;

//    //dedos de la mano izquierda
//    RigBone falangepulgar1i;
//    RigBone falangepulgar2i;
//    RigBone falangepulgar3i;

//    RigBone falangeindice1i;
//    RigBone falangeindice2i;
//    RigBone falangeindice3i;

//    RigBone falangemedio1i;
//    RigBone falangemedio2i;
//    RigBone falangemedio3i;

//    RigBone falangeanular1i;
//    RigBone falangeanular2i;
//    RigBone falangeanular3i;

//    RigBone falangemeñique1i;
//    RigBone falangemeñique2i;
//    RigBone falangemeñique3i;


//    void Start()
//{
//    //Iniciolizacion de codos
//    rightLowerArm = new RigBone(humanoid, HumanBodyBones.RightLowerArm);
//    leftLowerArm = new RigBone(humanoid, HumanBodyBones.LeftLowerArm);

//    rightHand = new RigBone(humanoid, HumanBodyBones.RightHand);
//    leftHand = new RigBone(humanoid,HumanBodyBones.LeftHand);


//    rightShoulder = new RigBone(humanoid, HumanBodyBones.RightShoulder);
//    leftShoulder = new RigBone(humanoid, HumanBodyBones.LeftShoulder);

//    }

//// Update is called once per frame
///// <summary>
///// 
///// </summary>
//void Update()
//    {
//        onPressButton();

//        rightLowerArm.set(xelbowRight,yelbowRight, zelbowRight);


//        humanoid.transform.rotation
//          = Quaternion.AngleAxis(bodyRotation.z, new Vector3(0,0,1))
//          * Quaternion.AngleAxis(bodyRotation.x, new Vector3(1, 0, 0))
//          * Quaternion.AngleAxis(bodyRotation.y, new Vector3(0, 1, 0));
//    }


//    void onPressButton() {
//        xelbowRight = 103;
//        if (yelbowRight > -225) yelbowRight++;
//        else if(yelbowRight < -225) yelbowRight--;
//        zelbowRight = -336;



//    }


//}
