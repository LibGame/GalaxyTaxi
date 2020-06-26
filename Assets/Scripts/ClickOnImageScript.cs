using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnImageScript : MonoBehaviour
{
    public float timeTabletIsUp = 3f;

    public void OnClickImageTimePoint(GameObject ImagePoint)
    {
        if (InterFace.PointAmountTime > 0)
        {
            InterFace.PointAmountTime--;

            GameProperties.BackGroundSpeed = 5f;
            GameProperties.SpeedEnemy = 2.5f;
            GameProperties.SpeedBarnel = 1f;
            GameProperties.SpeedEnemyCar = 5f;
            GameProperties.TimeDelteEnemyCar = 2f;
            GameProperties._speed = 5f;
            GameProperties.CopterSpeed = 0.5f;
            GameProperties.MoveSpeed = 0.25f;
            GameProperties.HardSpeed = 2f;
            GameProperties.speedHelio = 1.5f;
            GameProperties.speedOil = 1f;
            GameProperties.TabletSpeed = 1f;
            GameProperties.BosRocket = 1.5f;
            GameProperties.TankMoveSpeed = 1f;
            GameProperties.RotationTureSpeed = 20f;
            GameProperties.RotationTureSpeed1 = 2f;
            GameProperties.RocketSpeed = 2.5f;
            GameProperties.thirdBGSpeed = 0.2f;

            Invoke("TimeTabletIsUp", timeTabletIsUp);
        }
    }

    private void TimeTabletIsUp()
    {
        GameProperties.BackGroundSpeed = 10f;
        GameProperties.SpeedEnemy = 5f;
        GameProperties.SpeedBarnel = 2f;
        GameProperties.SpeedEnemyCar = 10f;
        GameProperties.TimeDelteEnemyCar = 4f;
        GameProperties._speed = 10f;
        GameProperties.CopterSpeed = 1f;
        GameProperties.MoveSpeed = 0.5f;
        GameProperties.HardSpeed = 4f;
        GameProperties.speedHelio = 3f;
        GameProperties.speedOil = 2f;
        GameProperties.TabletSpeed = 2f;
        GameProperties.BosRocket = 3f;
        GameProperties.TankMoveSpeed = 2f;
        GameProperties.RotationTureSpeed = 40f;
        GameProperties.RotationTureSpeed1 = 4f;
        GameProperties.RocketSpeed = 5f;
        GameProperties.thirdBGSpeed = 1f;

    }

}
