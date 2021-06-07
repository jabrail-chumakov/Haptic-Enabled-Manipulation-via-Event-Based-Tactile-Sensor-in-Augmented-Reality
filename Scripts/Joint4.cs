using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

//public class CRoot
//{
//    public string[] events;
//}
//[System.Serializable]
public class Joint4 : MonoBehaviour
{
    private ArticulationBody artBody1;
    private ArticulationBody artBody2;
    private ArticulationBody artBody3;
    private ArticulationBody artBody4;
    private ArticulationBody artBody5;
    private ArticulationBody artBody6;
    private ArticulationBody artBody7;

    SocketIn socket;

    //public GameObject panda;

    // Start is called before the first frame update
    void Start()
    {
        socket = GameObject.Find("panda").GetComponent<SocketIn>();
        artBody1 = GameObject.Find("panda_link1").GetComponent<ArticulationBody>();
        artBody2 = GameObject.Find("panda_link2").GetComponent<ArticulationBody>();
        artBody3 = GameObject.Find("panda_link3").GetComponent<ArticulationBody>();
        artBody4 = GameObject.Find("panda_link4").GetComponent<ArticulationBody>();
        artBody5 = GameObject.Find("panda_link5").GetComponent<ArticulationBody>();
        artBody6 = GameObject.Find("panda_link6").GetComponent<ArticulationBody>();
        artBody7 = GameObject.Find("panda_link7").GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Root root = JsonUtility.FromJson<CRoot>(socket.pos);

        //float[] player = JsonUtility.FromJson<float[]>(socket.pos);

        //Debug.Log(player[1]);

        artBody1.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint1, CultureInfo.InvariantCulture));
        artBody2.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint2, CultureInfo.InvariantCulture));
        artBody3.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint3, CultureInfo.InvariantCulture));
        artBody4.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint4, CultureInfo.InvariantCulture));
        artBody5.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint5, CultureInfo.InvariantCulture));
        artBody6.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint6, CultureInfo.InvariantCulture));
        artBody7.jointPosition = new ArticulationReducedSpace(float.Parse(socket.joint7, CultureInfo.InvariantCulture));
    }
}
