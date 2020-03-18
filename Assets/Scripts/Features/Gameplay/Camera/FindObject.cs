using System;
using UnityEngine;

/// <summary>
/// FindObject adds the CheckObject function to the OnCreatePhoto delegate.
/// CheckObject returns the closest object if the object is within the camera view.
/// </summary>
public class FindObject : MonoBehaviour
{
    private void Awake()
    {
        PhotoCameraApi.OnCreatePhoto += ()=>
        {
            GameObject foundObject = CheckObject();

            if (!foundObject)
                return;

			for (int i = 0; i < Properties.currentFindableItems.Length; i++)
			{
				if (Properties.currentFindableItems[i].model == foundObject)
				{
					PhotoCameraApi.FoundObject(i);
					break;
				}

			}
        };
    }

    /// <summary>
    /// CheckObject gets the closest object and checks if the object is fully inside the camera.
    /// </summary>
    /// <returns> If a findable gameobject is found within the camera view, return the closest gameobject. Else return null. </returns>
    private GameObject CheckObject()
    {
        int findableObjectsLength = Properties.currentFindableItems.Length;
        float closestDistance = 999;
        GameObject closestObject = null;

        for (int i = 0; i < findableObjectsLength; i++)
        {
            float distance = Vector2.Distance(Camera.main.transform.position, Properties.currentFindableItems[i].model.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = Properties.currentFindableItems[i].model;
            }
        }

		if (
			Camera.main.transform.position.x < closestObject.transform.position.x - 0.3 &&
			Camera.main.transform.position.x > closestObject.transform.position.x + 0.3
		)
			return null;

		if (closestDistance >= 2)
			return null;

		/*
        // Calculate if the closest object is completely inside the camera's view.
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        Vector3[] meshVerts = closestObject.GetComponent<MeshFilter>().mesh.vertices;

        for (int i = 0; i < 4; i++)
        {
            // If the vertex * normal of plane + distance of plane <= 0, the Vertex is not inside the plane.
            for (int j = 0; j < meshVerts.Length; j++)
            {
                Vector3 vertPos = closestObject.transform.position + transform.TransformPoint(meshVerts[j]);

                if (Vector3.Dot(vertPos, planes[i].normal) + planes[i].distance <= 0)
                {
                    // Object is not completely inside plane.
                    return null;
                }
            }
        }
		*/

        // Object is completely inside all planes.
        return closestObject;
    }
}
