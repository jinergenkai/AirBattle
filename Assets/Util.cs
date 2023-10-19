using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class Util
    {
        static public Vector2 Rotate(Vector2 v2, double angleInDegrees)
        {
            float X = v2.x;
            float Y = v2.y;
            double angleInRadians = Math.PI * angleInDegrees / 180.0;

            double cosAngle = Math.Cos(angleInRadians);
            double sinAngle = Math.Sin(angleInRadians);

            double newX = X * cosAngle - Y * sinAngle;
            double newY = X * sinAngle + Y * cosAngle;

            return new Vector2((float)newX, (float)newY);
        }

        static public Vector3[] getCorners(Camera mainCamera)
        {
            Vector3[] corners = new Vector3[4];
            float depth = 10f;

            corners[0] = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, depth));
            corners[1] = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, depth));
            corners[2] = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, depth));
            corners[3] = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, depth));

            return corners;
        }
    }
}
