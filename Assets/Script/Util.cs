using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    static public class Util
    {

        public enum e_bulletType
        {
            normalBullet,
            doubleBullet,
            tripleBullet,
            crossBullet,
            slowBullet,
            maxBulletType
        };

        public enum e_giftType
        {
            heartPlus,
            normalBullet,
            doubleBullet,
            tripleBullet,
            crossBullet,
            slowBullet,
            //laserBullet,
            maxGiftType
        }
        // Cộng dồn đạn theo chủng loại, x2,x3...
        // đạn laser cho boss và player, bắn laser xoay vòng tròn.
        // đạn shotgun
        // siêu xả đạn.
        // set restart game. method reset game.
        // đạn chậm, sau 1 thời gian sẽ phóng nhanh.
        // set sát thường từng loại đạn
        // địch bắn được đạn, nhiều loại địch.
        // setup moveset của địch AI.
        // boss.
        // độ khó game thăng tiến.
        // dash for player.
        // animation.




        static public string[] nameGiftAssets = { "heartPlus", "normalBullet", "doubleBullet", "tripleBullet", "crossBullet", "slowBullet"};


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
        static public Vector3[] getCornersPlus(Camera mainCamera)
        {
            Vector3[] corners = new Vector3[4];
            float depth = 10f;

            int tolerance = 20;

            corners[0] = mainCamera.ScreenToWorldPoint(new Vector3(0 - tolerance, 0 - tolerance, depth));
            corners[1] = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width + tolerance, 0 - tolerance, depth));
            corners[2] = mainCamera.ScreenToWorldPoint(new Vector3(0 - tolerance, Screen.height + tolerance, depth));
            corners[3] = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width + tolerance, Screen.height + tolerance, depth));

            return corners;
        }

        static public bool isOutOfScreen(Vector3[] corners, Vector3 position)
        {
            if (position.x < corners[0].x || position.x > corners[3].x || position.y < corners[0].y || position.y > corners[3].y)
            {
                return true;
            }
            return false;
        }
    }
}
