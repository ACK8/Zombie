using UnityEngine;
using System.Collections;

public class BoxDraw : MonoBehaviour
{
    public Material lineMaterial;

    private BoxCollider boxCollider;
    private Vector3[] vertex;

    public Transform m_Transform;

    void Start ()
    {
        boxCollider = GetComponent<BoxCollider>();

        float x = boxCollider.size.x;
        float y = boxCollider.size.y;
        float z = boxCollider.size.z;

        Vector3 center = boxCollider.center;

        vertex = new Vector3[8];

        vertex[0] = new Vector3(center.x + x, center.y + y, center.z + z); //右上
        vertex[1] = new Vector3(center.x + x, center.y + y, center.z - z); //左上
        vertex[2] = new Vector3(center.x + x, center.y - y, center.z - z); //左下
        vertex[3] = new Vector3(center.x + x, center.y - y, center.z + z); //右下

        vertex[4] = new Vector3(center.x - x, center.y + y, center.z + z); //右上
        vertex[5] = new Vector3(center.x - x, center.y + y, center.z - z); //左上
        vertex[6] = new Vector3(center.x - x, center.y - y, center.z - z); //左下
        vertex[7] = new Vector3(center.x - x, center.y - y, center.z + z); //右下
    }

    void Update ()
    {

    }

    void OnRenderObject()
    {
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(m_Transform.localToWorldMatrix);
        GL.Begin(GL.LINES);

        //+X側面
        {
            //上
            GL.Vertex3(vertex[0].x, vertex[0].y, vertex[0].z);
            GL.Vertex3(vertex[1].x, vertex[1].y, vertex[1].z);

            //下
            GL.Vertex3(vertex[2].x, vertex[2].y, vertex[2].z);
            GL.Vertex3(vertex[3].x, vertex[3].y, vertex[3].z);

            //右
            GL.Vertex3(vertex[0].x, vertex[0].y, vertex[0].z);
            GL.Vertex3(vertex[3].x, vertex[3].y, vertex[3].z);

            //左
            GL.Vertex3(vertex[1].x, vertex[1].y, vertex[1].z);
            GL.Vertex3(vertex[2].x, vertex[2].y, vertex[2].z);
        }

        //-X側面
        {
            //上
            GL.Vertex3(vertex[4].x, vertex[4].y, vertex[4].z);
            GL.Vertex3(vertex[5].x, vertex[5].y, vertex[5].z);

            //下
            GL.Vertex3(vertex[6].x, vertex[6].y, vertex[6].z);
            GL.Vertex3(vertex[7].x, vertex[7].y, vertex[7].z);

            //右
            GL.Vertex3(vertex[4].x, vertex[4].y, vertex[4].z);
            GL.Vertex3(vertex[7].x, vertex[7].y, vertex[7].z);

            //左
            GL.Vertex3(vertex[5].x, vertex[5].y, vertex[5].z);
            GL.Vertex3(vertex[6].x, vertex[6].y, vertex[6].z);
        }

        //上面
        {
            //+Z
            GL.Vertex3(vertex[0].x, vertex[0].y, vertex[0].z);
            GL.Vertex3(vertex[4].x, vertex[4].y, vertex[4].z);

            //-Z
            GL.Vertex3(vertex[1].x, vertex[1].y, vertex[1].z);
            GL.Vertex3(vertex[5].x, vertex[5].y, vertex[5].z);
        }

        //下面
        {
            //+Z
            GL.Vertex3(vertex[3].x, vertex[3].y, vertex[3].z);
            GL.Vertex3(vertex[7].x, vertex[7].y, vertex[7].z);

            //-Z
            GL.Vertex3(vertex[2].x, vertex[2].y, vertex[2].z);
            GL.Vertex3(vertex[6].x, vertex[6].y, vertex[6].z);
        }

        GL.End();
        GL.PopMatrix();
    }
}
